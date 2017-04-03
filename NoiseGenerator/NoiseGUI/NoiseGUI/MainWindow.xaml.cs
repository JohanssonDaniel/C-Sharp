using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MakeSomeNoise;
using Microsoft.Win32;
using Duration = MakeSomeNoise.Duration;

namespace NoiseGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Because enum cannot handle doubles, the octave multiple is stored in this dictionary 
        // and uses the octaves as key
        private static readonly Dictionary<Octave, double> Octaves = new Dictionary<Octave, double>()
            {
                {Octave.C1, 0.125 }, {Octave.C2, 0.25 }, {Octave.C3, 0.5 }, {Octave.C4, 1 },
                {Octave.C5, 2 },     {Octave.C6, 4 },    {Octave.C7, 8 },   {Octave.C8, 12 }, {Octave.C9, 16 }
            };

        private readonly Dictionary<string, WaveType> _waveTypeDictionary = new Dictionary<string, WaveType>()
        {
            {"Sawtooth", WaveType.Sawtooth },
            {"Sine", WaveType.SineWave },
            {"Square", WaveType.Square },
            {"Triangle", WaveType.Triangle },
            {"White Noise", WaveType.WhiteNoise }
        };

        private const int MAX_AMPLITUDE   = 32760; // Max amplitude for 16-bit audio
        private const string FREQ_VALUE   = "Frequency (Hz): ";
        private const string VOLUME_VALUE = "Volume: ";

        public MainWindow()
        {
            InitializeComponent();
            FreqSlider.Value   = FreqSlider.Maximum / 2;
            VolumeSlider.Value = VolumeSlider.Maximum / 2;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.ShowDialog();
            FileBox.Text = openDlg.FileName;
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (FileBox.Text == "")
            {
                MessageBox.Show("You have to choose a filepath first...");
            }
            else
            {
                string filePath = FileBox.Text;
                WaveType tempType;
                int amp = MAX_AMPLITUDE * (int)VolumeSlider.Value / 100;

                _waveTypeDictionary.TryGetValue(WaveTypeCombo.Text, out tempType);

                Wave wave = new Wave();
                wave.Generate(tempType, FreqSlider.Value, amp);
                wave.Save(filePath);

                SoundPlayer player = new SoundPlayer(filePath);
                player.Play();
            }
        }

        private void FreqSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FreqBox.Text = $"{FREQ_VALUE} {(int)FreqSlider.Value}";
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        { 
            VolumeBlock.Text = $"{VOLUME_VALUE} {(int)VolumeSlider.Value}%";
        }

        private void MelodyButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FileBox.Text;
            Wave wave = new Wave();

            if (FileBox.Text == "")
            {
                MessageBox.Show("You have to choose a filepath first...");
            }
            else
            {
                Note[] doReMi = {
                            new Note(Tone.C, Octave.C4, Duration.Whole),
                            new Note(Tone.D, Octave.C4, Duration.Whole),
                            new Note(Tone.E, Octave.C4, Duration.Whole),
                            new Note(Tone.F, Octave.C4, Duration.Whole),
                            new Note(Tone.G, Octave.C4, Duration.Whole),
                            new Note(Tone.A, Octave.C5, Duration.Whole),
                            new Note(Tone.B, Octave.C5, Duration.Whole),
                            new Note(Tone.C, Octave.C5, Duration.Whole)
                        };
                foreach (Note note in doReMi)
                {
                    WaveType tempType;
                    int amp = MAX_AMPLITUDE * (int)VolumeSlider.Value / 100;

                    _waveTypeDictionary.TryGetValue(WaveTypeCombo.Text, out tempType);

                    double tempFreq = (double)note.ToneValue * Octaves[note.OctaveValue];

                    wave.Generate(tempType,(double)note.ToneValue,amp);
                    wave.Save(filePath);
                }
            SoundPlayer player = new SoundPlayer(filePath);
            player.Play();
            }
        }
    }
}
