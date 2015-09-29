using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grabacr07.KanColleViewer.Composition;
using System.ComponentModel.Composition;
using KanColleShare.Views;
using KanColleShare.ViewModels;

namespace KanColleShare
{
    [Export(typeof(IPlugin))]
    [Export(typeof(ITool))]
    [Export(typeof(IRequestNotify))]
    [ExportMetadata("Guid", "4CA20EC7-4CA2-4723-A9D6-7A900354BBAD")]
    [ExportMetadata("Title", "KanColleShare")]
    [ExportMetadata("Description", "スクリーンショットをtwitterで共有します。")]
    [ExportMetadata("Version", "0.1.0")]
    [ExportMetadata("Author", "@terry_u16")]
    [Export(typeof(ISettings))]
    public class Plugin : IPlugin, ITool, IRequestNotify, ISettings
    {
        readonly ToolViewModel toolViewModel;
        readonly SettingsViewModel settingsViewModel;

        string ITool.Name => "Share";

        object ISettings.View => new ToolView { DataContext = toolViewModel };

        object ITool.View => new SettingsView { DataContext = settingsViewModel };

        public event EventHandler<NotifyEventArgs> NotifyRequested;

        public Plugin()
        {
            this.toolViewModel = new ToolViewModel();
            this.settingsViewModel = new SettingsViewModel();
        }

        public void Initialize()
        {
        }
    }
}
