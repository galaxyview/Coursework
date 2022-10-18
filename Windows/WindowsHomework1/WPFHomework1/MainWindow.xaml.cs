using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Threading;

namespace WPFHomework1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int BUFFER_SIZE = 20;
        static Mutex mutex = new Mutex();
        static Semaphore produce = new Semaphore(BUFFER_SIZE, BUFFER_SIZE);
        static Semaphore consume = new Semaphore(0, BUFFER_SIZE);
        int freeCapacity = 0;
        int occupiedCapacity = 0;
        int curAdd = 0;
        int TotalCapacity = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProduceItem(string name)
        {
            while (true)
            {
                while (!produce.WaitOne(10))
                {
                    Console.WriteLine(name + " wants to produce an item, but the buffer is full");
                    update(name + " wants to produce an item, but the buffer is full");
                }
                mutex.WaitOne();
                ++curAdd;
                occupiedCapacity++;
                
                Dispatcher.Invoke(new Action(() => {
                    listBox1.Items.Add(name + " produces an item, totally " + curAdd + ", now there are " + occupiedCapacity + " items in the buffer");
                }));

                mutex.ReleaseMutex();
                consume.Release();
                Thread.Sleep(500);

                if (curAdd >= TotalCapacity) break;
            }
        }

        private void ConsumeItem(string name)
        {
            while (true)
            {
                while (!consume.WaitOne(10))
                {
                    Console.WriteLine(name + " wants to consume an item, but the buffer is empty");
                }
                mutex.WaitOne();
                occupiedCapacity--;

                Dispatcher.Invoke(new Action(() => {
                    listBox1.Items.Add(name + " consumes an item, now there are " + occupiedCapacity + " items in the buffer");
                }));
                
                mutex.ReleaseMutex();
                produce.Release();
                Thread.Sleep(500);
                if (curAdd >= TotalCapacity) break;
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            int producerNum = 0;
            producerNum = int.Parse(ProducerNum.Text);
            if(producerNum <= 0)
            {
                MessageBox.Show("生产者数量只能大于0");
                return;
            }

            int consumerNum = 0;
            consumerNum = int.Parse(ConsumerNum.Text);
            if (consumerNum <= 0)
            {
                MessageBox.Show("消费者数量只能大于0");
                return;
            }

            int capacity = 0;
            capacity = int.Parse(capacityNum.Text);
            if (capacity <= 0)
            {
                MessageBox.Show("产品最大容量只能大于0");
                return;
            }
            freeCapacity = capacity;

            btn1.IsEnabled = false;
            ProducerConsumer(producerNum, consumerNum,capacity);
            btn1.IsEnabled = true;
            

        }

        void ProducerConsumer(int producerNum, int consumerNum, int capacity)
        {
            listBox1.Items.Clear();
            TotalCapacity = capacity;
            Thread[] producers = new Thread[producerNum];
            for (int i = 0; i < producerNum; i++)
            {
                producers[i] = new Thread(() => { ProduceItem("producer" + i); });
                producers[i].IsBackground = true;
                producers[i].Start();
            }
            Thread.Sleep(2000);

            Thread[] consumers = new Thread[consumerNum];
            for (int i = 0; i < consumerNum; i++)
            {
                consumers[i] = new Thread(() => { ConsumeItem("consumer" + i); });
                consumers[i].IsBackground = true;
                consumers[i].Start();
            }
            
        }

        void update(string comment)
        {
            if (!listBox1.Dispatcher.CheckAccess())
            {
                //声明，并实例化回调
                updateDelegate d = showComment;
                //使用回调
                listBox1.Dispatcher.Invoke(d, comment);
            }
            else
            {
                showComment((string)comment);
            }
        }
        private delegate void updateDelegate(string comment);
        void showComment(string comments)
        {
            listBox1.Items.Add(comments);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
