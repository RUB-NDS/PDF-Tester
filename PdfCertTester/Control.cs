
namespace PdfCertTester
{
    class Control
    {
        private string path;
        private string debugFilename;
        private string editor;

        private Debug deb;
        private Config conf;
        private ProcessManagement proc;
        private Screenshot shot;
        private Tester test;

        public Control()
        {
            path = Names.path;
            debugFilename = Names.debugFilename;
            editor = Names.editor;
            
            deb = new Debug(path, debugFilename);
            conf = new Config(path);
            proc = new ProcessManagement();
            shot = new Screenshot();
            test = new Tester();
        }

        public string createDebug()
        {
            return deb.createDebug();
        }

        public string openDebug()
        {
            return proc.processStart(editor, path + debugFilename);
        }

        public string writeDebug(string text)
        {
            return deb.writeDebug(text);
        }

        public string createConfig(string filename)
        {
            return conf.createConfig(filename);
        }

        public string readConfig(string filename)
        {
            return conf.readConfig(filename);
        }

        public string writeConfig(string content, string filename)
        {
            return conf.writeConfig(content, filename);
        }

        public string processStart(string filename, string argument)
        {
            return proc.processStart(filename, argument);
        }

        public string processStop(int id)
        {
            return proc.processStop(id);
        }

        public string makeScreenshot(string path)
        {
            return shot.makeScreenshot(path);
        }

        public string Compare(string img1, string img2)
        {
            return test.compare(img1, img2);
        }


    }
}
