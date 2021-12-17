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
using Theme = QTech.Base.Helpers.Theme;

namespace QTech.Forms
{
    public partial class MainForm : ExDialog
    {
        private List<MenuBar> _secondLevelMenue = new List<MenuBar>();
        private Dictionary<string, Form> _pages = new Dictionary<string, Form>();
        private ExTabItem _lastExtabitem = null;
        private List<MenuBar> _menuBars = new List<MenuBar>();
        public bool isReload = false;
        AuthKey currentKeyTab;

        public MainForm()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //this.FormClosing += (e, o) => DataBaseSetting.WriteSetting();
            ShareValue.permissions = PermissionLogic.Instance.SearchAsync(new PermissionSearch());

            ReportHelper.Instance.RegisterPath(@"QTech\QTech.App\Reports");
            _lblComanyName.Text = QTech.Base.Properties.Resources.Company;
            this.Text = string.Empty;
            ApplySetting();
            ResourceHelper.ApplyResource(this);
            this.InitForm();
            this.OptimizeLoadUI();
            this.FormClosed += MainForm_FormClosed1;
            this.Load += MainForm_Load;

            try
            {
                var jsonData = File.ReadAllText("Version.json");
                var version = JsonConvert.DeserializeObject<QTech.Base.Models.Version>(jsonData);
                _lblVersion.Text = $"v{version?.AppVersion}";
            }
            catch (Exception) { }
        }
        private void MainForm_FormClosed1(object sender, FormClosedEventArgs e)
        {
            if (!isReload)
            { 
                InputLanguage.CurrentInputLanguage = UI.English;
                DataBaseSetting.WriteSetting();
                Application.Exit();
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyMainFormTheme();
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
                        Theme = ShareValue.User.Theme,
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
                            secodMenue.Leave += SecodMenue_Leave;
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

        private void SecodMenue_Leave(object sender, EventArgs e)
        {
            if (sender is ExTabItem2 btn)
            {
                if (ShareValue.User.Theme == Base.Enums.Theme.Template1)
                {
                    btn.BackColor = ShareValue.CurrentTheme.MainFormSecondMenuePanel;
                    btn.ForeColor = ShareValue.CurrentTheme.LabelColor;
                    pSecondMenue2.Controls.OfType<ExTabItem2>().Where(x => x != btn).ToList()
                   .ForEach(y => { y.BackColor = Color.Transparent; y.ForeColor = ShareValue.CurrentTheme.LabelColor;});
                }
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
                if (ShareValue.User.Theme == Base.Enums.Theme.Template1)
                {
                    btn.BackColor = Color.FromArgb(37, 48, 62);
                    btn.ForeColor = Color.FromArgb(59, 143, 250);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(204, 232, 255);
                    pSecondMenue2.Controls.OfType<ExTabItem2>().Where(x => x != btn).ToList()
                    .ForEach(y => { y.BackColor = Color.Transparent; y.ForeColor = ShareValue.CurrentTheme.LabelColor; });
                }
                
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
            ForeColor = ShareValue.CurrentTheme.LabelColor;

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
        private void ApplyMainFormTheme()
        {
            var currentTheme = ShareValue.CurrentTheme;
            pTopMenu.BackColor = currentTheme.MainFormFirstMenuePanel;
            pSecondMenue2.BackColor = currentTheme.MainFormSecondMenuePanel;
            BackColor = currentTheme.MainFormBackColor;
            pBottom.Colors.Clear();
            pBottom.Colors.Add(new ColorWithAlpha() { Color = 
                currentTheme.MainFormFirstMenuePanel, Alpha = 255, Parent = pBottom });
            pContainBottom.Colors.Clear();
            pContainBottom.Colors.Add(new ColorWithAlpha() { Color = 
                currentTheme.MainFormFirstMenuePanel, Alpha = 255, Parent = pContainBottom });
            mainPanel.BackColor = currentTheme.FormBackGround;

            curvePanel.BackGroundColor = currentTheme.MainFormFirstMenuePanel;
            curvePanel.BackColor = currentTheme.MainFormSecondMenuePanel;
            labelHideCurveBg_.BackColor = currentTheme.MainFormFirstMenuePanel;
            picLogo.BackColor = currentTheme.MainFormFirstMenuePanel;

            txtLogin.ForeColor = currentTheme.LabelColor;
            txtUserName.ForeColor = currentTheme.LabelColor;
            label5.ForeColor = currentTheme.LabelColor;
            _lblVersion.ForeColor = currentTheme.LabelColor;
            _lblVersion.LinkColor = currentTheme.LabelColor;
            _lblComanyName.BackColor = currentTheme.MainFormFirstMenuePanel;
            lblTheme_.ForeColor = currentTheme.LabelColor;



            digheader.Colors.Clear();
            digheader.Colors.Add(new ColorWithAlpha()
            {
                Color =
                currentTheme.FormTopBar,
                Alpha = 255,
                Parent = digheader
            });
            digheader.Colors.Add(new ColorWithAlpha()
            {
                Color =
                currentTheme.FormTopBar,
                Alpha = 255,
                Parent = digheader
            });
            digheader.Colors.Add(new ColorWithAlpha()
            {
                Color =
                currentTheme.FormTopBar,
                Alpha = 255,
                Parent = digheader
            });
        }

        private void _lblTheme_Click(object sender, EventArgs e)
        {
            var p = Point.Add(_lblTheme.PointToScreen(new Point(0, -50)), new Size(0, _lblTheme.Height));
            cnmTheme.Show(p);
        }

        private void Template1_Click(object sender, EventArgs e)
        {
            isReload = false;
            ShareValue.CurrentTheme = Theme.Template1;
            var currentTheme = ShareValue.User.Theme;
            ShareValue.User.Theme = Base.Enums.Theme.Template1;
            UserLogic.Instance.UpdateAsync(ShareValue.User);
            if (currentTheme != Base.Enums.Theme.Template1)
            {
                isReload = true;
                var obj = this;
                 this.Hide();
                new ReloadMainForm(obj).Show();
            }
        }

        private void Template2_Click(object sender, EventArgs e)
        {
            isReload = false;
            ShareValue.CurrentTheme = Theme.Template2;
            var currentTheme = ShareValue.User.Theme;
            ShareValue.User.Theme = Base.Enums.Theme.Template2;
            UserLogic.Instance.UpdateAsync(ShareValue.User);
            if (currentTheme != Base.Enums.Theme.Template2)
            {
                isReload = true;
                var obj = this;
                this.Hide();
                new ReloadMainForm(obj).Show();
            }
        }

        private void Template3_Click(object sender, EventArgs e)
        {
            isReload = false;
            ShareValue.CurrentTheme = Theme.Template3;
            var currentTheme = ShareValue.User.Theme;
            ShareValue.User.Theme = Base.Enums.Theme.Template3;
            UserLogic.Instance.UpdateAsync(ShareValue.User);
            if (currentTheme != Base.Enums.Theme.Template3)
            {
                isReload = true;
                this.Hide();
                new ReloadMainForm(this).Show();
            }
        }
    }
}
