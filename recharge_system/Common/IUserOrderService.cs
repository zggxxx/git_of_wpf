using MySql.Data.MySqlClient;
using recharge_system.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace recharge_system.Common
{
    interface IUserOrderService
    {
        public List<BillInfo> GetBillInfos();
    }

    public class UserOrderService : IUserOrderService 
    {

        public UserOrderService() 
        {

        }

        public List<BillInfo> GetBillInfos() 
        {
            try
            {
                MySqlConnectionStringBuilder sqlConStrBuilder = new MySqlConnectionStringBuilder();
                sqlConStrBuilder.MaximumPoolSize = 20;
                sqlConStrBuilder.MinimumPoolSize = 5;
                sqlConStrBuilder.Server = "192.168.169.130";
                sqlConStrBuilder.Port = 3306;
                sqlConStrBuilder.UserID = "root";
                sqlConStrBuilder.Database = "im_wpf_mvvmlearning";
                sqlConStrBuilder.Password = "19960621";
                using (MySqlConnection connection = new MySqlConnection(sqlConStrBuilder.ConnectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = @"select
	                                            tup.order_id ,
	                                            tup.create_time,
	                                            tui.user_name,
	                                            tii.item_name,
	                                            titi.item_type_name 
                                            from
	                                            tb_user_purchase tup
                                            left join tb_user_info tui on
	                                            tup.user_id = tui.user_id 
                                            left join tb_item_info tii on
	                                            tii.item_id = tup.item_id
                                            left join tb_item_type_info titi on 
	                                            titi.item_type_id  = tii.item_id;";

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                List<BillInfo> billInfos = new List<BillInfo>();
                                while (reader.Read())
                                {
                                    BillInfo billInfo = new BillInfo();
                                    billInfo.BillNo = reader.GetInt32("order_id");
                                    billInfo.ItemName = reader.GetString("item_name");
                                    billInfo.UserName = reader.GetString("user_name");
                                    billInfo.ItemType = reader.GetString("item_type_name");
                                    billInfo.OrderTime = reader.GetDateTime("create_time");
                                    billInfos.Add(billInfo);
                                }
                                return billInfos;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"错误信息",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            return null;
        }

    }
}
