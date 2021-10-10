using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuyShot.Options;
using TuyShot.Options.PictureBoxOptions;

namespace TuyShot
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var task = Task.Run((Func<Task>)Program.Run);
            task.Wait();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ControlPanelForm());
        }

        static string _token = "rjr3EtqAgdQAAAAAAAAAAfF5vekyeZHoM4xCuwos4FVDo-CXozFRDK8ZKJzX10Dn";
        static async Task Run()
        {
            using (var dbx = new DropboxClient(_token))
            {
                string folder = "";
                string file = "appUpdate.json";
                using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
                {
                    var d = response.GetContentAsByteArrayAsync();
                    d.Wait();
                    var s = d.Result;
                    File.WriteAllBytes(file, s);
                }
            }
        }
    }
}
