using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace CS319_Genius
{
    public partial class InterfaceManager : MetroFramework.Forms.MetroForm
    {
        public delegate void inputEvent(string input);
        public event inputEvent inputEventTrigger;

        public delegate void searchSelectionChange(short selection); // 0 -> Nothing selected, 1 -> Google Selected, 2 -> Wiki Selected
        public event searchSelectionChange searchSelectionChecker;
         
        private OptionsLayer optionsLayer;
        private HelpLayer helplayer;

        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        public InterfaceManager()
        {            
            optionsLayer = new OptionsLayer(0,0);
            helplayer    = new HelpLayer(0,0);
            this.Controls.Add(optionsLayer.getPanel());
            this.Controls.Add(helplayer.getPanel());
            optionsLayer.setVisibility(false);
            helplayer.setVisibility(false);
            optionsLayer.settingsChanged += OptionsLayer_settingsChanged;
            InitializeComponent();
            optionsLayer.autoSetLocation(optionsButton.Location.X+optionsButton.Width, optionsButton.Location.Y + optionsButton.Height);
            helplayer.autoSetLocation(helpButton.Location.X + helpButton.Width, helpButton.Location.Y+ helpButton.Height);

            Choices commands = new Choices();
            commands.Add(new string []{ "Open", "Execute","Close","Kill","Start","Search","Wikipedia","Google"});
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);
            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += RecEngine_SpeechRecognized;
            Console.WriteLine("Should started ??");
            recEngine.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void RecEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Detected! : " + e.Result.Text);
        }

        private void OptionsLayer_settingsChanged(bool googleCheck, bool wikiCheck)
        {
            if (googleCheck)
                searchSelectionChecker(1);
            else
            {
                if (wikiCheck)
                    searchSelectionChecker(2);
                else
                    searchSelectionChecker(0);
            }
        }
        
        private void MainUI_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Closing all tabs...");
            optionsLayer.setVisibility(false);
        }


        private void optionsButton_Click(object sender, EventArgs e)
        {
            

            if (!optionsLayer.getVisibility())
            {
                Console.WriteLine("Opening options...");
                optionsLayer.setVisibility(true);
                // Check options 
                if (helplayer.getVisibility())
                    helplayer.setVisibility(false);
            }
            else
            {
                Console.WriteLine("Closing options...");
                optionsLayer.setVisibility(false);
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {                
            if (!helplayer.getVisibility())
            {
                Console.WriteLine("Opening help...");
                helplayer.setVisibility(true);
                // Check options 
                if (optionsLayer.getVisibility())
                    optionsLayer.setVisibility(false);
            }
            else
            {
                Console.WriteLine("Closing help...");
                helplayer.setVisibility(false);
            }
        }

        private void title_Click(object sender, EventArgs e)
        {
            helplayer.setVisibility(false);
            optionsLayer.setVisibility(false);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string tempUserString = inputBox.Text;
            inputBox.Text = "";
            logBox.Text = logBox.Text + "\r\nUser:" + tempUserString;

            // CALL EVENT SO YOU CAN RETURN STRING TO DISPATCHER
            inputEventTrigger(tempUserString);
        }


        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tempUserString = inputBox.Text;
                inputBox.Text = "";
                logBox.Text = logBox.Text + "\r\nUser:" + tempUserString;

                // CALL EVENT SO YOU CAN RETURN STRING TO DISPATCHER
                inputEventTrigger(tempUserString);
            }
        }


        public void setOutput (string output)
        {
            // Set output string which comes from Dispatcher 
            logBox.Text = logBox.Text + "\r\nGenius:" + output;
            
            // Experimental ...
            SpeechSynthesizer geniusVoice = new SpeechSynthesizer();
            geniusVoice.Volume = 100;
            Console.WriteLine("Adjusting voice speed... Incoming string length  " + output.Length);
            int speakSpeed = (int)((output.Length) / 20);
            if (speakSpeed > 12) speakSpeed = 10;
            geniusVoice.Rate = -2 + speakSpeed;
            geniusVoice.SpeakAsync(output);

        }


    }
}
