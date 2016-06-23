using System;
using System.Windows.Forms;
//////////////////////////////////////////////////////////////////////////////////////
//
//  Copyright (c) 2014-2015, 王胜国
//  All rights reserved.
//  email 49480040@qq.com
//
//////////////////////////////////////////////////////////////////////////////////////
namespace NWebGather.Forms
{
    public partial class MDIParentMain : Form
    {
        private FrmGatherWorker _formCommonTask;
        private FrmAbout _formAbout;

        public MDIParentMain()
        {
            InitializeComponent();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void tsbtnCommonTask_Click(object sender, EventArgs e)
        {
            OpenCommonTask();
        }
        /// <summary>
        /// 打开普通采集任务窗口
        /// </summary>
        private void OpenCommonTask()
        {
            if (_formCommonTask == null || _formCommonTask.IsDisposed)
            {
                _formCommonTask = new FrmGatherWorker { MdiParent = this };
            }
            _formCommonTask.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formAbout == null || _formAbout.IsDisposed)
            {
                _formAbout = new FrmAbout { MdiParent = this };
            }
            _formAbout.Show();
        }

        private void MDIParentMain_Load(object sender, EventArgs e)
        {
            OpenCommonTask();
        }

        private void tsmiCommonTask_Click(object sender, EventArgs e)
        {
            OpenCommonTask();
        }
    }
}
