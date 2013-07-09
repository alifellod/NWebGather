namespace NWebGather.Forms
{
    partial class FrmGatherWorker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWebTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWebContent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContentPageUrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStartUrl = new System.Windows.Forms.TextBox();
            this.rtxtMessage = new System.Windows.Forms.RichTextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.ckbIsSaveOnlyFile = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbDefaultEncode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSaveTask = new System.Windows.Forms.Button();
            this.ckbIsStartClearMessageBox = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTaskList = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSamePageMark = new System.Windows.Forms.TextBox();
            this.ckbIsDealSamePage = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFirstPageMark = new System.Windows.Forms.TextBox();
            this.rdbGatherModel_PageByPage = new System.Windows.Forms.RadioButton();
            this.rdbGatherModel_List = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtListPageUrl = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnFormatConfig = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.nudGatherCountMax = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtSourceName = new System.Windows.Forms.TextBox();
            this.btnOpenDirectory = new System.Windows.Forms.Button();
            this.ttMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudGatherCountMax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "任务名称：";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(71, 60);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(250, 21);
            this.txtTaskName.TabIndex = 3;
            this.txtTaskName.Text = "500年来谁著史";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "页面标题：";
            // 
            // txtWebTitle
            // 
            this.txtWebTitle.Location = new System.Drawing.Point(71, 143);
            this.txtWebTitle.Name = "txtWebTitle";
            this.txtWebTitle.Size = new System.Drawing.Size(511, 21);
            this.txtWebTitle.TabIndex = 6;
            this.txtWebTitle.Text = "\"article-sectioname\">(?<value>.*?)</div>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "页面内容：";
            // 
            // txtWebContent
            // 
            this.txtWebContent.Location = new System.Drawing.Point(71, 170);
            this.txtWebContent.Name = "txtWebContent";
            this.txtWebContent.Size = new System.Drawing.Size(511, 21);
            this.txtWebContent.TabIndex = 7;
            this.txtWebContent.Text = "\"bk-article-body\">(?<value>[\\s\\S]*?)</div>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(597, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "正则，参数名为value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(597, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "正则，参数名为value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(597, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "正则，参数名为value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "页面链接：";
            // 
            // txtContentPageUrl
            // 
            this.txtContentPageUrl.Location = new System.Drawing.Point(71, 197);
            this.txtContentPageUrl.Name = "txtContentPageUrl";
            this.txtContentPageUrl.Size = new System.Drawing.Size(511, 21);
            this.txtContentPageUrl.TabIndex = 8;
            this.txtContentPageUrl.Text = "返回目录页</a>[\\s\\S]*?<a href=\"(?<value>.*?)\" target=\"_self\"[\\s\\S]*?id=\"nextsection\">下" +
    "一章</a>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "起始网址：";
            // 
            // txtStartUrl
            // 
            this.txtStartUrl.Location = new System.Drawing.Point(71, 87);
            this.txtStartUrl.Name = "txtStartUrl";
            this.txtStartUrl.Size = new System.Drawing.Size(511, 21);
            this.txtStartUrl.TabIndex = 4;
            this.txtStartUrl.Text = "http://data.book.163.com/book/section/0000JFbX/0000JFbX0.html";
            // 
            // rtxtMessage
            // 
            this.rtxtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtMessage.Location = new System.Drawing.Point(12, 387);
            this.rtxtMessage.Name = "rtxtMessage";
            this.rtxtMessage.Size = new System.Drawing.Size(632, 156);
            this.rtxtMessage.TabIndex = 22;
            this.rtxtMessage.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(469, 348);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 20;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(569, 348);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 21;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "保存路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(71, 251);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(286, 21);
            this.txtSavePath.TabIndex = 12;
            this.txtSavePath.Text = "C:\\Users\\Administrator\\Desktop\\gather\\";
            // 
            // ckbIsSaveOnlyFile
            // 
            this.ckbIsSaveOnlyFile.AutoSize = true;
            this.ckbIsSaveOnlyFile.Checked = true;
            this.ckbIsSaveOnlyFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsSaveOnlyFile.Location = new System.Drawing.Point(474, 256);
            this.ckbIsSaveOnlyFile.Name = "ckbIsSaveOnlyFile";
            this.ckbIsSaveOnlyFile.Size = new System.Drawing.Size(108, 16);
            this.ckbIsSaveOnlyFile.TabIndex = 13;
            this.ckbIsSaveOnlyFile.Text = "保存为一个文件";
            this.ckbIsSaveOnlyFile.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(597, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "/文件名";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "默认编码：";
            // 
            // cmbDefaultEncode
            // 
            this.cmbDefaultEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefaultEncode.FormattingEnabled = true;
            this.cmbDefaultEncode.Items.AddRange(new object[] {
            "gb2312",
            "utf-8"});
            this.cmbDefaultEncode.Location = new System.Drawing.Point(71, 279);
            this.cmbDefaultEncode.Name = "cmbDefaultEncode";
            this.cmbDefaultEncode.Size = new System.Drawing.Size(121, 20);
            this.cmbDefaultEncode.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(212, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "先自动获取编码，获取失败，采用默认编码";
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.Location = new System.Drawing.Point(370, 348);
            this.btnSaveTask.Name = "btnSaveTask";
            this.btnSaveTask.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTask.TabIndex = 19;
            this.btnSaveTask.Text = "保存任务";
            this.btnSaveTask.UseVisualStyleBackColor = true;
            this.btnSaveTask.Click += new System.EventHandler(this.btnSaveTask_Click);
            // 
            // ckbIsStartClearMessageBox
            // 
            this.ckbIsStartClearMessageBox.AutoSize = true;
            this.ckbIsStartClearMessageBox.Checked = true;
            this.ckbIsStartClearMessageBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsStartClearMessageBox.Location = new System.Drawing.Point(474, 282);
            this.ckbIsStartClearMessageBox.Name = "ckbIsStartClearMessageBox";
            this.ckbIsStartClearMessageBox.Size = new System.Drawing.Size(120, 16);
            this.ckbIsStartClearMessageBox.TabIndex = 15;
            this.ckbIsStartClearMessageBox.Text = "开始时清空消息框";
            this.ckbIsStartClearMessageBox.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "任务列表：";
            // 
            // cmbTaskList
            // 
            this.cmbTaskList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskList.FormattingEnabled = true;
            this.cmbTaskList.Items.AddRange(new object[] {
            "gb2312",
            "utf8"});
            this.cmbTaskList.Location = new System.Drawing.Point(71, 7);
            this.cmbTaskList.Name = "cmbTaskList";
            this.cmbTaskList.Size = new System.Drawing.Size(511, 20);
            this.cmbTaskList.TabIndex = 0;
            this.cmbTaskList.SelectedIndexChanged += new System.EventHandler(this.cmbTaskList_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 229);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "分页标识：";
            // 
            // txtSamePageMark
            // 
            this.txtSamePageMark.Location = new System.Drawing.Point(71, 224);
            this.txtSamePageMark.Name = "txtSamePageMark";
            this.txtSamePageMark.Size = new System.Drawing.Size(121, 21);
            this.txtSamePageMark.TabIndex = 9;
            this.txtSamePageMark.Text = "(\\d*?)";
            this.ttMain.SetToolTip(this.txtSamePageMark, "可以是正则表达式");
            // 
            // ckbIsDealSamePage
            // 
            this.ckbIsDealSamePage.AutoSize = true;
            this.ckbIsDealSamePage.Checked = true;
            this.ckbIsDealSamePage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsDealSamePage.Location = new System.Drawing.Point(474, 228);
            this.ckbIsDealSamePage.Name = "ckbIsDealSamePage";
            this.ckbIsDealSamePage.Size = new System.Drawing.Size(240, 16);
            this.ckbIsDealSamePage.TabIndex = 11;
            this.ckbIsDealSamePage.Text = "分页处理(不重复标题或合并在一个文件)";
            this.ckbIsDealSamePage.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(256, 228);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "首页标识：";
            // 
            // txtFirstPageMark
            // 
            this.txtFirstPageMark.Location = new System.Drawing.Point(317, 223);
            this.txtFirstPageMark.Name = "txtFirstPageMark";
            this.txtFirstPageMark.Size = new System.Drawing.Size(121, 21);
            this.txtFirstPageMark.TabIndex = 10;
            this.txtFirstPageMark.Text = "(1)";
            this.ttMain.SetToolTip(this.txtFirstPageMark, "普通字符，非正则表达式");
            // 
            // rdbGatherModel_PageByPage
            // 
            this.rdbGatherModel_PageByPage.AutoSize = true;
            this.rdbGatherModel_PageByPage.Checked = true;
            this.rdbGatherModel_PageByPage.Location = new System.Drawing.Point(71, 35);
            this.rdbGatherModel_PageByPage.Name = "rdbGatherModel_PageByPage";
            this.rdbGatherModel_PageByPage.Size = new System.Drawing.Size(47, 16);
            this.rdbGatherModel_PageByPage.TabIndex = 1;
            this.rdbGatherModel_PageByPage.TabStop = true;
            this.rdbGatherModel_PageByPage.Text = "逐页";
            this.rdbGatherModel_PageByPage.UseVisualStyleBackColor = true;
            this.rdbGatherModel_PageByPage.CheckedChanged += new System.EventHandler(this.rdbGatherModel_CheckedChanged);
            // 
            // rdbGatherModel_List
            // 
            this.rdbGatherModel_List.AutoSize = true;
            this.rdbGatherModel_List.Location = new System.Drawing.Point(136, 35);
            this.rdbGatherModel_List.Name = "rdbGatherModel_List";
            this.rdbGatherModel_List.Size = new System.Drawing.Size(47, 16);
            this.rdbGatherModel_List.TabIndex = 2;
            this.rdbGatherModel_List.Text = "列表";
            this.rdbGatherModel_List.UseVisualStyleBackColor = true;
            this.rdbGatherModel_List.CheckedChanged += new System.EventHandler(this.rdbGatherModel_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "采集模式：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 119);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "列表网址：";
            // 
            // txtListPageUrl
            // 
            this.txtListPageUrl.Location = new System.Drawing.Point(71, 114);
            this.txtListPageUrl.Name = "txtListPageUrl";
            this.txtListPageUrl.Size = new System.Drawing.Size(511, 21);
            this.txtListPageUrl.TabIndex = 5;
            this.txtListPageUrl.Text = "<a href=\"(?<value>.*?)\">Next ></a>";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(597, 119);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "正则，参数名为value";
            // 
            // btnFormatConfig
            // 
            this.btnFormatConfig.Location = new System.Drawing.Point(12, 348);
            this.btnFormatConfig.Name = "btnFormatConfig";
            this.btnFormatConfig.Size = new System.Drawing.Size(75, 23);
            this.btnFormatConfig.TabIndex = 18;
            this.btnFormatConfig.Text = "格式化设置";
            this.btnFormatConfig.UseVisualStyleBackColor = true;
            this.btnFormatConfig.Click += new System.EventHandler(this.btnFormatConfig_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 314);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "采集上限：";
            // 
            // nudGatherCountMax
            // 
            this.nudGatherCountMax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudGatherCountMax.Location = new System.Drawing.Point(71, 308);
            this.nudGatherCountMax.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudGatherCountMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGatherCountMax.Name = "nudGatherCountMax";
            this.nudGatherCountMax.Size = new System.Drawing.Size(120, 21);
            this.nudGatherCountMax.TabIndex = 16;
            this.nudGatherCountMax.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(212, 314);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(137, 12);
            this.label20.TabIndex = 17;
            this.label20.Text = "超过设定次数，自动停止";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(333, 65);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "网站名称：";
            // 
            // txtSourceName
            // 
            this.txtSourceName.Location = new System.Drawing.Point(394, 60);
            this.txtSourceName.Name = "txtSourceName";
            this.txtSourceName.Size = new System.Drawing.Size(188, 21);
            this.txtSourceName.TabIndex = 3;
            this.txtSourceName.Text = "网易";
            // 
            // btnOpenDirectory
            // 
            this.btnOpenDirectory.Location = new System.Drawing.Point(363, 249);
            this.btnOpenDirectory.Name = "btnOpenDirectory";
            this.btnOpenDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnOpenDirectory.TabIndex = 19;
            this.btnOpenDirectory.Text = "打开目录";
            this.btnOpenDirectory.UseVisualStyleBackColor = true;
            this.btnOpenDirectory.Click += new System.EventHandler(this.btnOpenDirectory_Click);
            // 
            // FrmGatherWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 555);
            this.Controls.Add(this.nudGatherCountMax);
            this.Controls.Add(this.rdbGatherModel_List);
            this.Controls.Add(this.rdbGatherModel_PageByPage);
            this.Controls.Add(this.cmbTaskList);
            this.Controls.Add(this.cmbDefaultEncode);
            this.Controls.Add(this.ckbIsStartClearMessageBox);
            this.Controls.Add(this.ckbIsDealSamePage);
            this.Controls.Add(this.ckbIsSaveOnlyFile);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnFormatConfig);
            this.Controls.Add(this.btnOpenDirectory);
            this.Controls.Add(this.btnSaveTask);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rtxtMessage);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFirstPageMark);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSamePageMark);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtContentPageUrl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWebContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtListPageUrl);
            this.Controls.Add(this.txtStartUrl);
            this.Controls.Add(this.txtWebTitle);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSourceName);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.label1);
            this.Name = "FrmGatherWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采集工作台";
            ((System.ComponentModel.ISupportInitialize)(this.nudGatherCountMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWebTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWebContent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContentPageUrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStartUrl;
        private System.Windows.Forms.RichTextBox rtxtMessage;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.CheckBox ckbIsSaveOnlyFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbDefaultEncode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSaveTask;
        private System.Windows.Forms.CheckBox ckbIsStartClearMessageBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbTaskList;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSamePageMark;
        private System.Windows.Forms.CheckBox ckbIsDealSamePage;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtFirstPageMark;
        private System.Windows.Forms.RadioButton rdbGatherModel_PageByPage;
        private System.Windows.Forms.RadioButton rdbGatherModel_List;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtListPageUrl;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnFormatConfig;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown nudGatherCountMax;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtSourceName;
        private System.Windows.Forms.Button btnOpenDirectory;
        private System.Windows.Forms.ToolTip ttMain;
    }
}