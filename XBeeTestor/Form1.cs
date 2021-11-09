using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBee;

namespace XBeeTestor
{
    public partial class Form1 : Form
    {
        public SerialPort serialPort = null;

        private ControlLog controlLog;
        private string[] comlist;
        private CancellationTokenSource cts = null;
        private static XBeeController xbeeController;
        private static XBeeNode node12;
        private static XBeeNode node27;
        private static XBeeNode node28;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitPortComboBox()
        {
            comboBoxPort.Items.Clear();
            comlist = SerialPort.GetPortNames();
            if (comlist.Length > 0)
            {
                comboBoxPort.Items.AddRange(comlist);
                comboBoxPort.SelectedIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controlLog = new ControlLog();
            PanelLog.Controls.Add(controlLog);

            InitPortComboBox();
            comboBoxPort.FlatStyle = FlatStyle.Popup;
            comboBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //리시브 정보 적용
        private void SetText(string text)
        {
            controlLog.SetLogText(text);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            //재퍼슨
            if (cts != null)
            {
                cts.Cancel();
                cts = null;
            }

            cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            var task1 = Task.Run(() =>
            {
                while (cts != null)
                {
                    string message = textBoxData.Text;
                    Send(message);
                    try
                    {
                        Task.Delay(800, cts.Token).Wait();
                    }
                    catch
                    {
                        System.Diagnostics.Trace.WriteLine($"Stop");
                    }
                }
            });

            return;

            //최초
            //if (cts != null)
            //{
            //    cts.Cancel();
            //    cts = null;
            //}
            //if (serialPort != null)
            //{
            //    if (textBoxData.Text.Length > 0 && serialPort.IsOpen)
            //    {
            //        cts = new CancellationTokenSource();
            //        CancellationToken token = cts.Token;
            //        var task1 = Task.Run(() =>
            //        {
            //        //여기 수정
            //            while (cts != null)
            //            {
            //                //abc
            //                //Console.WriteLine("Send");
            //                Console.WriteLine(textBoxData.Text);
            //                //byte[] data = Encoding.UTF8.GetBytes($"AT+BROADCAST={textBoxData.Text}\r");
            //                byte[] data = Encoding.UTF8.GetBytes($"{textBoxData.Text}\r");
            //                //Console.WriteLine(BitConverter.ToString(data));
            //                serialPort.Write(data, 0, data.Length);
            //                try
            //                {
            //                    Task.Delay(5000, cts.Token).Wait();
            //                }
            //                catch
            //                {
            //                    System.Diagnostics.Trace.WriteLine($"Stop");
            //                }
            //            }
            //        });
            //    }
            //}
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
                cts = null;
            }
        }

        private static async void Send(string message)
        {
            try
            {
                if (node12 != null)
                {
                    await node12.TransmitDataAsync(Encoding.UTF8.GetBytes(message));
                }

                if (node27 != null)
                {
                    await node27.TransmitDataAsync(Encoding.UTF8.GetBytes(message));
                }

                if (node28 != null)
                {
                    await node28.TransmitDataAsync(Encoding.UTF8.GetBytes(message));
                }
            }
            catch { }
        }

        private void ComboBoxPort_DropDown(object sender, EventArgs e)
        {
            string[] new_comlist = SerialPort.GetPortNames();

            if (!Enumerable.SequenceEqual(comlist, new_comlist))
            {
                string OldText = comboBoxPort.Text;
                comboBoxPort.Items.Clear();
                comlist = new_comlist;
                comboBoxPort.Items.AddRange(comlist);
                comboBoxPort.Text = OldText;
            }
        }

        private async void Run(string portName)
        {
            xbeeController = new XBeeController();
            //이게 안됨
            xbeeController.NodeDiscovered += Node_Discovered;
            xbeeController.SampleReceived += Node_SampleReceived;

            //xbeeController.NodeDiscovered += async (sender, args) =>
            //{
            //    Console.WriteLine("Discovered {0}", args.Name);
            //    // setup some pins
            //    await args.Node.SetInputOutputConfigurationAsync(InputOutputChannel.Channel2, InputOutputConfiguration.DigitalIn);
            //    await args.Node.SetInputOutputConfigurationAsync(InputOutputChannel.Channel3, InputOutputConfiguration.AnalogIn);
            //    // set sample rate
            //    await args.Node.SetSampleRateAsync(TimeSpan.FromSeconds(5));
            //    // register callback for sample recieved from this node
            //    // TODO: in practice you would want to make sure you only subscribe once (or better yet use Rx)
            //    args.Node.SampleReceived += (node, sample) => Console.WriteLine("Sample recieved: {0}", sample);
            //};

            await xbeeController.OpenAsync(portName, 9600);
            //xbeeController.DiscoverNetworkAsync(5);
            //await xbeeController.DiscoverNetworkAsync();

            try
            {
                //Incorrect Test
                //node = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(0x0013A200444D07D4)));

                //COM12
                if (portName != "COM12")
                {
                    try
                    {
                        //ulong
                        node12 = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(5526146540966100)));
                        //S3
                        //node12 = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(0x0013A200418D10D4)));
                        //S2
                        //node12 = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(0x0013A200416761EA)));
                        //node12.DataReceived += Node_DataReceived;
                    }
                    catch { }
                }

                ////COM27
                if (portName != "COM27")
                {
                    try
                    {
                        //ulong
                        node27 = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(5526146540969612)));
                        //S3
                        //node27 = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(0x0013A200418D1E8C)));
                        //S2
                        //node27 = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(0x0013A200416761E9)));
                        //node27.DataReceived += Node_DataReceived;
                    }
                    catch { }
                }

                //COM28
                if (portName != "COM28")
                {
                    try
                    {
                        //ulong
                        node28 = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(5526146540963796)));
                        //node28 = await xbeeController.GetNodeAsync(new NodeAddress(new LongAddress(0x0013A200418D07D4)));
                        //node28.DataReceived += Node_DataReceived;
                    }
                    catch { }
                }

                xbeeController.DataReceived += XbeeController_DataReceived;
            }
            catch { }
        }

        private void XbeeController_DataReceived(object sender, SourcedDataReceivedEventArgs e)
        {
            string buff = Encoding.ASCII.GetString(e.Data, 0, e.Data.Length);
            if (buff.Length > 0)
            {
                SetText(buff);
            }
        }

        private void Node_SampleReceived(object sender, SourcedSampleReceivedEventArgs e)
        {
            Console.WriteLine("SampleReceive {0}", e.Address);
        }

        private void Node_Discovered(object sender, NodeDiscoveredEventArgs e)
        {
            Console.WriteLine("Discovered {0}", e.Name);
        }

        private void Node_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string buff = Encoding.ASCII.GetString(e.Data, 0, e.Data.Length);
            if (buff.Length > 0)
            {
                SetText(buff);
            }
            //Console.WriteLine("Received: {0}", BitConverter.ToString(e.Data));
        }

        private void ButtonOpen_Click(object sender2, EventArgs e)
        {
            string portName = comboBoxPort.Text;
            Run(portName);

            return;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (xbeeController != null)
            {
                xbeeController.Dispose();
            }
            return;
        }
    }
}
