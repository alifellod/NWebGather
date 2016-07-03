using System;
using System.Text;
using System.Windows.Forms;
using NWebGather.Framework;
using NWebGather.Helper;
using System.IO;
using System.Xml.Serialization;
using System.Web;
using System.Threading;
using System.Diagnostics;
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Forms
{
    public partial class FrmGatherWorker : Form
    {
        private Task _task;
        private Config _config;
        private HttpClient _httpRequest;
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Task));
        private FileStream _curSavaFile;
        private FrmFormatConfig _formatConfigForm;

        public FrmGatherWorker()
        {
            InitializeComponent();
            cmbDefaultEncode.SelectedIndex = 0;
            _httpRequest = new HttpClient();
            _httpRequest.AllowAutoRedirect = true;
            string[] files = Directory.GetFiles(SysConfig.TaskConfigPath, "*.xml");
            cmbTaskList.DataSource = files;
            if (files.Length > 0)
            {
                LoadGatherConfig();
            }
            rtxtMessage.LinkClicked += rtxtMessage_LinkClicked;
        }

        private void rtxtMessage_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!WorkInit())
                return;

            btnStart.Enabled = false;

            Worker work = new Worker(_httpRequest, _config, _task);
            work.OnError += w_OnError;
            work.OnWorkItemEnd += work_OnWorkItemEnd;
            work.OnWorkEnd += work_OnWorkEnd;
            _curSavaFile = new FileStream("{0}{1}-{2:MM-dd}.txt".FormatWith(_task.SavePath, _task.TaskName,DateTime.Now), FileMode.Create, FileAccess.ReadWrite);

            UpdateWorkMessage("采集处理开始");

            //执行任务
            if (_task.GatherModel == "逐页")
            {
                new Thread(work.GatherWorkWithPageByPage).Start();
            }
            else
            {
                new Thread(work.GatherWorkWithList).Start();
            }
        }
        /// <summary>
        /// 一次(个网址)采集完成后，执行内容写入文件操作
        /// </summary>
        private void work_OnWorkItemEnd(string curWebTitle, string curWebContent, string curUrl)
        {
            curWebTitle = curWebTitle ?? "";
            //将采集到的内容写入到文件流中
            byte[] byteWebContent = Encoding.UTF8.GetBytes(curWebContent);
            if (_task.IsSaveOnlyFile)
            {
                //如果当前内容标题为空，则可能分页
                if (!string.IsNullOrEmpty(curWebTitle))
                {
                    byte[] byteWebTitle = Encoding.UTF8.GetBytes(curWebTitle);
                    _curSavaFile.Write(byteWebTitle, 0, byteWebTitle.Length);
                }
                _curSavaFile.Write(byteWebContent, 0, byteWebContent.Length);
            }
            else
            {
                using (FileStream curSavaFile2 = new FileStream("{0}{1}.txt".FormatWith(_task.SavePath, curWebTitle), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    curSavaFile2.Write(byteWebContent, 0, byteWebContent.Length);
                }
            }
            UpdateWorkMessage("\n已采集：{0} 网址：{1}".FormatWith(curWebTitle.Trim(), curUrl));
            Application.DoEvents();
        }

        private void work_OnWorkEnd()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(work_OnWorkEnd));
            }
            else
            {
                btnStart.Enabled = true;
                UpdateWorkMessage("\n*******工作完成******\n");
                _curSavaFile.Close();
            }
        }

        private void w_OnError(Exception ex, ErrorType errorType, string curUrl)
        {
            MessageBox.Show("采集发送错误，错误类型：" + errorType.ToString() + "详情：\n" + StringFormat.FormatExceptionString(ex), "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateWorkMessage(string msg)
        {
            if (InvokeRequired)
            {

                Invoke(new MethodInvoker(() => UpdateWorkMessage(msg)));
            }
            else
            {
                rtxtMessage.AppendText(msg);
                rtxtMessage.Select(rtxtMessage.Text.Length, 0);
                rtxtMessage.ScrollToCaret();
            }
        }


        private void btnTest_Click(object sender, EventArgs e)
        {
            if (!WorkInit())
                return;
            _task.GatherCountMax = 2;
            btnTest.Enabled = false;

            Worker workTest = new Worker(_httpRequest, _config, _task);
            workTest.OnError += w_OnError;
            workTest.OnWorkItemEnd += workTest_OnWorkItemEnd;
            workTest.OnWorkEnd += workTest_OnWorkEnd;

            UpdateWorkMessage("采集处理开始\n");

            //执行任务
            if (_task.GatherModel == "逐页")
            {
                new Thread(workTest.GatherWorkWithPageByPage).Start();
            }
            else
            {
                new Thread(workTest.GatherWorkWithList).Start();
            }
        }

        private void workTest_OnWorkEnd()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(workTest_OnWorkEnd));
            }
            else
            {
                btnTest.Enabled = true;
                UpdateWorkMessage("\n*******工作完成******\n");
            }
        }

        private void workTest_OnWorkItemEnd(string curWebTitle, string curWebContent, string curUrl)
        {
            UpdateWorkMessage("\n***页面标题：{0}\n".FormatWith(curWebTitle.Trim()));
            UpdateWorkMessage("***页面网址：{0}\n".FormatWith(curUrl));
            UpdateWorkMessage("***页面内容：\n{0}\n".FormatWith(curWebContent));
            Application.DoEvents();
        }
        /// <summary>
        /// 采集工作初始化
        /// </summary>
        /// <returns></returns>
        private bool WorkInit()
        {

            if (ckbIsStartClearMessageBox.Checked)
            {
                rtxtMessage.Clear();
            }
            UpdateWorkMessage("采集正在初始化...\n");
            //检查输入是否合法
            if (!CheckInput())
            {
                return false;
            }
            //先保存配置
            SaveConfig(true);
            _config = FrmFormatConfig.GetConfig();
            if (_config == null)
            {
                MessageBox.Show("html格式化配置不存在，请先设置再开始", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            _task = GetTaskModelFromInput();
            return true;
        }

        #region 检查任务参数输入

        /// <summary>
        /// 检查任务参数输入是否正确
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtTaskName.Text))
            {
                MessageBox.Show("任务名称输入为空", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTaskName.Focus();
                return false;
            }

            if (!RequestHelper.IsUrl(txtStartUrl.Text))
            {
                MessageBox.Show("开始网址输入为空", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStartUrl.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtWebTitle.Text))
            {
                MessageBox.Show("网页标题正则输入为空", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWebTitle.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtWebContent.Text))
            {
                MessageBox.Show("网页内容正则输入为空", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtWebContent.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtContentPageUrl.Text))
            {
                MessageBox.Show("下一个网页正则输入为空", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContentPageUrl.Focus();
                return false;
            }
            string savePath = txtSavePath.Text;
            if (string.IsNullOrEmpty(savePath) || !Directory.Exists(savePath))
            {
                MessageBox.Show("保存路径输入错误", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSavePath.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cmbDefaultEncode.Text))
            {
                MessageBox.Show("默认编码输入为空", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDefaultEncode.Focus();
                return false;
            }

            Encoding ed = Encoding.GetEncoding(cmbDefaultEncode.Text);
            _httpRequest = new HttpClient();
            _httpRequest.Encoder = ed;
            return true;
        }
        #endregion

        /// <summary>
        /// 根据选择的已保存任务加载采集配置
        /// </summary>
        private void LoadGatherConfig()
        {
            try
            {
                Task t = _xmlSerializer.Deserialize(new MemoryStream(File.ReadAllBytes(cmbTaskList.Text))) as Task;
                if (t == null)
                {
                    MessageBox.Show("配置错误，无法加载", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //--设置数据类属性

                txtTaskName.Text = t.TaskName;
                txtSourceName.Text = t.SourceName;
                SetGatherModelSelect(t.GatherModel);
                txtStartUrl.Text = t.StartUrl;
                txtListPageUrl.Text = t.ListPageUrl;//HttpUtility.UrlDecode(
                txtWebTitle.Text = t.WebTitle;
                txtWebContent.Text = t.WebContent;
                txtContentPageUrl.Text = t.ContentPageUrl;
                txtSavePath.Text = t.SavePath;
                ckbIsSaveOnlyFile.Checked = t.IsSaveOnlyFile;
                ckbIsStartClearMessageBox.Checked = t.IsStartClearMessageBox;

                nudGatherCountMax.Value = t.GatherCountMax < nudGatherCountMax.Minimum ? nudGatherCountMax.Minimum : t.GatherCountMax;
                if (cmbDefaultEncode.Items.Contains(t.DefaultEncode))
                {
                    cmbDefaultEncode.Text = t.DefaultEncode;
                }
                else
                {
                    MessageBox.Show("默认编码不在编码列表中，已被设置为程序默认。", "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDefaultEncode.Focus();
                }
                ckbIsDealSamePage.Checked = t.IsDealSamePage;
                txtFirstPageMark.Text = HttpUtility.UrlDecode(t.FirstPageMark);
                txtSamePageMark.Text = HttpUtility.UrlDecode(t.SamePageMark);
            }
            catch (Exception ex)
            {
                MessageBox.Show(StringFormat.FormatExceptionString(ex), "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            SaveConfig(false);
        }
        private void SaveConfig(bool quiesceDeal)
        {
            string fileName = "{2}{0} - {1}.xml".FormatWith(txtTaskName.Text, txtSourceName.Text, SysConfig.TaskConfigPath);
            //如果已存在同名的文件，则提示是否覆盖，如果选择覆盖，则继续。
            bool isRecover = quiesceDeal;
            if (!quiesceDeal && File.Exists(fileName))
            {
                if (MessageBox.Show("输入的任务名称已经存在，是否覆盖。", "网络采集器", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    isRecover = true;
                }
                else
                {
                    txtTaskName.Focus();
                    return;
                }
            }
            try
            {
                TextWriter writer = new StreamWriter(fileName, false);
                //--序列化到XML
                _xmlSerializer.Serialize(writer, GetTaskModelFromInput());
                writer.Close();
                if (!isRecover)
                {
                    string[] items = cmbTaskList.DataSource as string[];
                    if (items != null)
                    {
                        string[] newItems = new string[items.Length + 1];
                        newItems[0] = fileName;
                        items.CopyTo(newItems, 1);
                        cmbTaskList.DataSource = newItems;
                    }
                }
                if (!quiesceDeal)
                    UpdateWorkMessage("任务已保存\n");

            }
            catch (Exception ex)
            {
                MessageBox.Show(StringFormat.FormatExceptionString(ex), "网络采集器", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 根据输入，返回任务数据实体
        /// </summary>
        /// <returns></returns>
        private Task GetTaskModelFromInput()
        {
            Task t = new Task();
            t.TaskName = txtTaskName.Text;
            t.SourceName = txtSourceName.Text;
            t.GatherModel = GetGatherModelText();
            t.StartUrl = txtStartUrl.Text;
            t.ListPageUrl = StringFormat.EscapeCharacterDecode(txtListPageUrl.Text);
            t.WebTitle = StringFormat.EscapeCharacterDecode(txtWebTitle.Text);
            t.WebContent = StringFormat.EscapeCharacterDecode(txtWebContent.Text);
            t.ContentPageUrl = StringFormat.EscapeCharacterDecode(txtContentPageUrl.Text);
            t.SavePath = txtSavePath.Text;
            t.IsSaveOnlyFile = ckbIsSaveOnlyFile.Checked;
            t.IsStartClearMessageBox = ckbIsStartClearMessageBox.Checked;
            t.DefaultEncode = cmbDefaultEncode.Text;
            t.IsDealSamePage = ckbIsDealSamePage.Checked;
            t.FirstPageMark = StringFormat.EscapeCharacterDecode(txtFirstPageMark.Text);
            t.SamePageMark = StringFormat.EscapeCharacterDecode(txtSamePageMark.Text);
            t.GatherCountMax = (long)nudGatherCountMax.Value;
            return t;
        }
        /// <summary>
        /// 根据选择的采集的模式 返回模式的名称
        /// </summary>
        /// <returns></returns>
        private string GetGatherModelText()
        {
            if (rdbGatherModel_List.Checked)
            {
                return "列表";
            }
            return "逐页";
        }

        /// <summary>
        /// 根据输入的采集的模式的名称，设置选中单选框
        /// </summary>
        /// <param name="gatherModel"></param>
        private void SetGatherModelSelect(string gatherModel)
        {
            switch (gatherModel)
            {
                case "逐页":
                    rdbGatherModel_PageByPage.Checked = true;
                    txtListPageUrl.Enabled = false;
                    break;
                case "列表":
                    rdbGatherModel_List.Checked = true;
                    txtListPageUrl.Enabled = true;
                    break;
            }

        }
        private void rdbGatherModel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGatherModel_List.Checked)
            {
                txtListPageUrl.Enabled = true;
            }
            else
            {
                txtListPageUrl.Enabled = false;
                txtListPageUrl.Text = string.Empty;
            }
        }

        private void btnFormatConfig_Click(object sender, EventArgs e)
        {
            if (_formatConfigForm == null)
                _formatConfigForm = new FrmFormatConfig();
            _formatConfigForm.ShowDialog();
        }

        private void btnOpenDirectory_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSavePath.Text))
            {
                Process.Start(txtSavePath.Text);
            }
            else
            {
                MessageBox.Show("输入的是一个不存在的路径", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTaskList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGatherConfig();
        }

    }
}
