
using FastMember;
using QTech.Base;
using QTech.Base.BaseReport;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using QTech.ReportModels;
using QTech.Reports;
using Storm.CC.Report.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseReource = QTech.Base.Properties.Resources;
using EasyServer.Domain.Helpers;
using EDomain = EasyServer.Domain;
using WpfCustomControlLibrary;
using System.Globalization;

namespace QTech.Forms
{
    public partial class frmSale : ExDialog, IDialog
    {
        public Sale Model { get; set; }
        public GeneralProcess Flag { get; set; }
        public frmSale(Sale model, GeneralProcess flag)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flag;
            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);
            this.ApplyResource();
            Read();
            InitEvent();
            this.QTechResturantDefaultStyle(this.Controls);
        }

        public void Read()
        {
            WindowState = FormWindowState.Maximized;
            for (int i = 1; i < 100; i++)
            {
                Table table = new Table()
                {
                    TableName = "តុលេខ " + i,
                    TableColor = Color.LightGreen,
                    Detail = "មិនទាន់មាន",
                    Width = 400,
                    Height = 300
                };
                table.TableClick += Table_TableClick;
                pnl.AddChildren(table);
            }
        }

        private void Table_TableClick(object sender, EventArgs e)
        {
        }

        public void InitEvent()
        {
            //var ci = new CultureInfo("km-kh");
            timer.Start();
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("km-kh");
            DateTime dt = DateTime.Parse(DateTime.Now.ToString(), cultureinfo);

            lblDate_.Text = dt.ToLongDateString();
            //lblDate_.Text = KhmerLunar.getKhmerLunarString(DateTime.Now);
        }

        public void Write()
        {
        }

        public void Bind()
        {
        }

        public bool InValid()
        {
            return false;
        }

        public void Save()
        {
        }

        public void ViewChangeLog()
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer.Start();
        }
    }
}
