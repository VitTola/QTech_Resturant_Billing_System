   using Storm.Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using QTech.Component;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base;
using QTech.Forms;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Db;
using Storm.CC.Report.Helpers;
using QTech.Base.Helpers;
using QTech.Db.Logics;
using QTech.Base.SearchModels;
using System.IO;
using Newtonsoft.Json;
using Updater;

namespace QTech.Forms
{
    public partial class MainForm : ExDialog
    {
        private List<MenuBar> _secondLevelMenue = new List<MenuBar>();
        private Dictionary<string, Form> _pages = new Dictionary<string, Form>();
        private ExTabItem _lastExtabitem = null;
        private List<MenuBar> _menuBars = new List<MenuBar>();
        AuthKey currentKeyTab;

        public MainForm()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            this.FormClosing += (e, o) => DataBaseSetting.WriteSetting();
            //ShareValue.permissions = PermissionLogic.Instance.SearchAsync(new PermissionSearch());

            ReportHelper.Instance.RegisterPath(@"QTech\QTech.App\Reports");
            _lblComanyName.Text = QTech.Base.Properties.Resources.Company;
            this.Text = string.Empty;
            ApplySetting();
            ResourceHelper.ApplyResource(this);
            this.InitForm();
            this.OptimizeLoadUI();
            this.FormClosed += (s, e) => Application.Exit();

            try
            {
                var jsonData = File.ReadAllText("Version.json");
                var version = JsonConvert.DeserializeObject<QTech.Base.Models.Version>(jsonData);
                _lblVersion.Text = $"v{version?.AppVersion}";
            }
            catch (Exception) { }
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            pSecondMenue1.ResumeLayout(false);
            pSecondMenue2.ResumeLayout(false);
            container.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            pBottom.ResumeLayout(false);
            pBottom.PerformLayout();
            pBranch.ResumeLayout(false);
            pBranch.PerformLayout();
            mainPanel.ResumeLayout(false);
            graPanel2.ResumeLayout(false);
            graPanel3.ResumeLayout(false);
            pContainBottom.ResumeLayout(false);
           // ResumeLayout(false);
        }
        private void ApplySetting()
        {
            txtUserName.Text = ShareValue.User?.Name ?? string.Empty;
            txtLogin.Text = DateTime.Now.ToLongDateString();
            var moduleManager = ModuleManager.Instance;
            _menuBars = moduleManager.GetMenubars();
            InitMenu();
            
        }
        public void InitMenu()
        {
            //CAN CHECK THE WITH AUTHORIZE KEY IN HERE BEFORE READTOPMENUE

            AddTopMenue(_menuBars);
        }
        private void AddTopMenue(List<MenuBar> topMenuBars)
        {
            topMenuBars.OrderByDescending(x => x.Index).ToList()
                .ForEach(x =>
                {
                    var topMenue = new ExTabItem
                    {
                        Height = 60,
                        Name = x.FormName,
                        Tag = x.Key,
                        Text = x.DisplayName,
                        Image = x.Icon,
                        TextAlignment = ContentAlignment.MiddleLeft,
                        BorderStyle = BorderStyle.None,
                        Padding = new Padding() { All = 0 },
                    };
                    if (ShareValue.IsAuthorized(x.Key))
                    {
                        pTopMenu.AddTabItem(topMenue);
                        topMenue.Click += TopMenue_Click;
                        _lastExtabitem = topMenue;
                    }
                });
            if (_lastExtabitem != null)
            {
                TopMenue_Click(_lastExtabitem, EventArgs.Empty);
                _lastExtabitem.Selected = true;
            }
        }
        private MenuBar ClickedButton;
        private void TopMenue_Click(object sender, EventArgs e)
        {
            var key = ((ExTabItem)sender).Tag ?? string.Empty;
            var navMenu = _menuBars.FirstOrDefault(y => y.Key.ToString() == key.ToString());

            currentKeyTab = navMenu.Key;
            pTopMenu.Text = navMenu.DisplayName;
            ShowPage(navMenu.FormName, navMenu.ModuleLocation);
            ReadSecondLevelMenue(navMenu);
        }
        public void ShowPage(string formname, string moduleLocation)
        {
            if (string.IsNullOrEmpty(formname))
            {
                return;
            }
            if (_pages.ContainsKey(formname) == false)
            {
                //Assembly assembly = Assembly.LoadFrom(@"moduleLocation");
                //Type type = assembly.GetType(formname);

                Assembly assembly = Assembly.GetExecutingAssembly();
                Type type = assembly.GetType(formname);
                if (!(Activator.CreateInstance(type) is Form form)) return;
                form.TopLevel = false;
                form.Enabled = true;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                pContainForm.Controls.Add(form);
                _pages.Add(formname, form);
                ResourceHelper.ApplyResource(form);
                form.Show();
            }
            if (pContainForm.Tag is Form oldForm)
            {
                oldForm.Hide();
            }

            pContainForm.Controls.SetChildIndex(_pages[formname], 0);
            pContainForm.Tag = _pages[formname];
            _pages[formname].Show();
            pContainForm.SelectNextControl(pContainForm, true, true, true, true);
            if (_pages[formname] is IPage page)
            {
                page.Reload();
                _lastPage = _pages[formname];
            }
            if (_pages[formname] is IPageReport pageReport)
            {
                pageReport.Reload();
                _lastPage = _pages[formname];
            }
        }
        private Form _lastPage;
        public void ShowDialog(string formname, string moduleLocation)
        {
            if (_pages.ContainsKey(formname) == false)
            {
                Assembly assembly = Assembly.LoadFrom(Environment.CurrentDirectory);
                Type type = assembly.GetType(formname);
                var form = Activator.CreateInstance(type) as Form;
                form.ShowDialog();
                if (_lastPage != null && _lastPage is IPage page)
                {
                    page.Reload();
                }
            }
        }
        private void ReadSecondLevelMenue(MenuBar menuBar)
        {
            var moduleManager = ModuleManager.Instance;
            _secondLevelMenue = moduleManager._secondLevelMenue;

            if (ClickedButton == menuBar && _secondLevelMenue.Any(x => x.ParentKey == menuBar.Key))
            {
                pSecondMenue2.Show();
                pSecondMenue1.Show();
            }
            else
            {
                pSecondMenue2.Hide();
                pSecondMenue1.Hide();

                pSecondMenue2.Controls.Clear();
                if (menuBar == null || _secondLevelMenue == null)
                {
                    return;
                }

                var childButtons = _secondLevelMenue.Where(n => n.ParentKey == menuBar.Key).OrderBy(x => x.Index).ToList();
                if (childButtons.Any())
                {
                    childButtons.ForEach(x =>
                    {
                        if (ShareValue.IsAuthorized(x.Key))
                        {
                            var secodMenue = MyTemplateButton(x.DisplayName, x.Icon, x);
                            pSecondMenue2.Controls.Add(secodMenue);
                            secodMenue.Click += SecodMenue_Click;
                        }
                    });
                    if (pSecondMenue2.Controls.Count > 0)
                    {
                        pSecondMenue1.Show();
                        pSecondMenue2.Show();
                        if (pSecondMenue2?.Controls[0] is ExTabItem2 btn)
                        {
                            SecodMenue_Click(btn, EventArgs.Empty);
                        }
                    }
                }

                ClickedButton = menuBar;
            }
        }
        private void SecodMenue_Click(object sender, EventArgs e)
        {
            if (sender is ExTabItem2 btn)
            {
                if (btn.Tag is MenuBar menuBar)
                {
                    ShowPage(menuBar.FormName, menuBar.ModuleLocation);
                }
                btn.BackColor = Color.FromArgb(250, 193, 196);
                pSecondMenue2.Controls.OfType<ExTabItem2>().Where(x => x != btn).ToList()
                    .ForEach(y => y.BackColor = Color.Transparent);
            }
        }
        private ExTabItem2 MyTemplateButton(string text, Image image, Object obj)
        {
            var btn = new ExTabItem2();
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ImageAlign = ContentAlignment.TopCenter;
            btn.TextAlign = ContentAlignment.BottomCenter;
            btn.Height = 70;
            btn.BackColor = Color.Transparent;
            btn.ExItem2Text = text;
            btn.Image = image;
            btn.Tag = obj;

            return btn;
        }
        private void _btnUpDown_Click(object sender, EventArgs e)
        {
            if (pSecondMenue2.Visible == false)
            {
                pSecondMenue2.Show();
                pSecondMenue1.Show();
            }
            else
            {
                pSecondMenue2.Hide();
                pSecondMenue1.Hide();
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            InputLanguage.CurrentInputLanguage = UI.English;
        }
        private void lblUserDropDown__Click(object sender, EventArgs e)
        {
            var p = Point.Add(lblUserProfile_.PointToScreen(new Point(0, -50)), new Size(0, lblUserProfile_.Height));
            //Point p = new Point(lblUserProfile_.Left, pContainBottom.Top - cnmStrip.Height + 22);
            cnmStrip.Show(p);
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath, "QTech.exe"));
        }

        private void txtVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartUpdater();
        }

        private void _lblComanyName_Click(object sender, EventArgs e)
        {
            StartUpdater();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            StartUpdater();
        }
        private void StartUpdater()
        {
            try
            {
                var path = Path.Combine(Application.StartupPath, "Updater.exe");
                System.Diagnostics.Process.Start(path);

                //new AboutUsDialog().ShowDialog();
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message, "Error");
            }
        }
    }
}
