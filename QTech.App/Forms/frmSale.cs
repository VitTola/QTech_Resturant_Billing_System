
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
using Table = WpfCustomControlLibrary.Table;

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

        public async void Read()
        {
            var tables = await this.RunAsync(() => TableLogic.Instance.SearchAsync(new TableSearch()));
            if (tables != null)
            {
                foreach (var t in tables)
                {
                    Table table = new Table()
                    {
                        TableName = t.Name,
                        TableColor = t.TableStus == TableStatus.Free ? Color.Green : Color.FromArgb(128, 128, 255),
                        Detail = "មិនទាន់មាន",
                        Width = 400,
                        Height = 300
                    };
                    table.TableClick += Table_TableClick;
                    pnl.AddChildren(table);
                }
            }
           
        }

        private void Table_TableClick(object sender, EventArgs e)
        {
        }

        public void InitEvent()
        {
            timer.Start();
            //lblDate_.Text = KhmerDate.GetKhmerDate(DateTime.Now);

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
            timer.Start();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
