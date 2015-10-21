using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace WcfSample01Client
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// エンドポイントアドレス
        /// </summary>
        private const string ENDPOINT_ADDRESS = @"http://localhost:8081/WCFSample001/SayHello";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            ActiveControl = btnCallSerivceMethod;
        }

        private void btnCallSerivceMethod_Click(object sender, EventArgs e)
        {
            //
            // クライアントの構築.
            //
            // WCFにて、クライアント側は以下の処理を行う必要がある。
            //
            //   1.エンドポイントアドレスの構築
            //   2.ChannelFactoryの構築
            //   3.サービスの呼び出し
            //
            // 通常、WCFでは直接ChannelFactoryなどを構築せず
            // 「サービス参照の追加」を利用して、クライアントプロキシを自動生成する。
            //
            // さらに、エンドポイントアドレスの設定などは、アプリケーション構成ファイルに
            // 設定するのが通例となる。
            //
            // エンドポイントアドレスの構築.
            EndpointAddress endpointAddr = new EndpointAddress(ENDPOINT_ADDRESS);

            string result = String.Empty;
            try
            {
                //
                // チャネルを構築しサービス呼び出しを行う.
                //
                using (ChannelFactory<IMyService> channel = new ChannelFactory<IMyService>(new BasicHttpBinding()))
                {
                    //
                    // サービスへのプロキシを取得.
                    //
                    IMyService service = channel.CreateChannel(endpointAddr);

                    //
                    // サービスメソッドの呼び出し.
                    //
                    result = service.SayHello("WCF Study");

                    //
                    // チャネルを閉じる.
                    //
                    channel.Close();
                }
            }
            catch (CommunicationException ex)
            {
                //
                // エラーが発生.
                // 
                // WCFでは、サービスとクライアント間の通信中にエラーが発生した場合
                // CommunicationExceptionがスローされる。
                //
                MessageBox.Show(ex.Message);
            }

            lblResult.Text = result;
        }



    }
}