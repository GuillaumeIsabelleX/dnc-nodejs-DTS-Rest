
using System;
using System.Collections;

using System.Collections.Generic;
using System.Collections.Specialized;
namespace FXCMCommands
{

    public class FXCMCommander
    {

        //// close the program

        //exit

        //

        //// request a list of all available symbols
        public string GetSymbols => "send { \"method\":\"GET\", \"resource\":\"/trading/get_instruments\" }";

        //

        //// request a snapshot of trading tables
        public string TradingTableGetOffer => "send { \"method\":\"GET\", \"resource\":\"/trading/get_model\", \"params\": { \"models\":[\"Offer\"] } }";
        public string TradingTableGetAccount => "send { \"method\":\"GET\", \"resource\":\"/trading/get_model\", \"params\": { \"models\":[\"Account\"] } }";
        public string TradingTableGetPositions => "send { \"method\":\"GET\", \"resource\":\"/trading/get_model\", \"params\": { \"models\":[\"Offer\",\"OpenPosition\",\"ClosedPosition\",\"Order\",\"Account\", \"Summary\",\"LeverageProfile\",\"Properties\"] } }";

        //

        //// update symbols subscribed to in Offers tables
        public string symbol_subscribe => "send { \"method\":\"POST\", \"resource\":\"/trading/update_subscriptions\", \"params\": { \"symbol\":\"EUR/USD\", \"visible\":true } }";
        public string symbol_unsubscribe => "send { \"method\":\"POST\", \"resource\":\"/trading/update_subscriptions\", \"params\": { \"symbol\":\"EUR/USD\", \"visible\":false } }";

        //

        //

        //// open a position with market order
        public string OpenPosition => "send { \"method\":\"POST\", \"resource\":\"/trading/open_trade\", \"params\": { \"account_id\":\"1027808\", \"symbol\":\"EUR/USD\", \"is_buy\":true, \"amount\":1, \"time_in_force\":\"FOK\" } }";
        public void OpenPositionACtion(string account, string symbol, int amount, bool isBuy) { }

        public string cmd19 => "send { \"method\":\"POST\", \"resource\":\"/trading/open_trade\", \"params\": { \"account_id\":\"1027808\", \"symbol\":\"EUR/USD\", \"is_buy\":true, \"amount\":10, \"time_in_force\":\"FOK\" } }";

        //

        //// close a position with market order
        public string ClosedPosition => "send { \"method\":\"POST\", \"resource\":\"/trading/close_trade\", \"params\": { \"amount\":1, \"time_in_force\":\"GTC\", \"trade_id\":\"123778283\" } }";

        //

        //// create an entry order
        public string create_entry_order => "send { \"method\":\"POST\", \"resource\":\"/trading/create_entry_order\", \"params\": { \"account_id\":\"1027808\", \"symbol\":\"EUR/USD\", \"is_buy\":true, \"rate\":1.22, \"amount\":10 } }";

        //

        //// modify waiting order
        public string change_order => "send { \"method\":\"POST\", \"resource\":\"/trading/change_order\", \"params\": { \"order_id\":\"241163945\", \"rate\":1.21, \"amount\":2 } }";
        public string change_order2 => "send { \"method\":\"POST\", \"resource\":\"/trading/change_order\", \"params\": { \"order_id\":\"241163945\", \"rate\":1.22, \"amount\":1 } }";

        //

        //// delete waiting order
        public string delete_order => "send { \"method\":\"POST\", \"resource\":\"/trading/delete_order\", \"params\": { \"order_id\":\"241163945\" } }";

        //

        //// request historical price data
        public string request_history1 => "send { \"method\":\"GET\", \"resource\":\"/candles/1/m1\", \"params\": { \"num\":10 } }";
        public string request_history2 => "send { \"method\":\"GET\", \"resource\":\"/candles/1/m1\", \"params\": { \"num\":1, \"from\":1519084679, \"to\":1519430400 } }";
        public string request_history3 => "send { \"method\":\"GET\", \"resource\":\"/candles/1/d1\", \"params\": { \"num\":1, \"from\":1515024000, \"to\":1516752000 } }";
        public string request_history4 => "send { \"method\":\"GET\", \"resource\":\"/candles/1/d1\", \"params\": { \"num\":1, \"from\":1515456000, \"to\":1517529600 } }";

        //

        //--- Live Prices module ---
        public string price_subscribe_loadmodule => "load {\"filename\":\"liveprices.js\"}";

        //
        public string price_subscribe => "price_subscribe {\"pairs\":\"EUR/USD\"}";
        public LivePriceSubscriber liveprices_subscribe2(string symbol)
        {
            //todo fire an event
            return null;
        }
        public string price_subscribe_many => "price_subscribe {\"pairs\":[\"GBP/USD\",\"USD/JPY\"]}";
        public Dictionary<string, LivePriceSubscriber> price_subscribe_many_command(string[] symbols)
        {
            var r = new Dictionary<string, LivePriceSubscriber>();
            //todo fire an event
            foreach (var s in symbols
            )
            {
                r.Add(s, new LivePriceSubscriber(s));
            }
            return r;
        }
        public string price_unsubscribe_many => "price_unsubscribe {\"pairs\":[\"EUR/USD\",\"GBP/USD\",\"USD/JPY\"]}";

        //

        //--- Trading Tables module ---
        public string load_trading_table_module => "load {\"filename\":\"tradingtables.js\"}";

        //
        public string table_subscribe => "table_subscribe {\"tables\":\"Offer\"}";
        public string table_subscribe_many => "table_subscribe {\"tables\":[\"Offer\",\"Order\"]}";
        public string table_unsubscribe => "table_unsubscribe {\"tables\":[\"Offer\",\"Order\"]}";

        //

        //
        public string Send => "send { \"method\":\"POST\", \"resource\":\"/trading/subscribe\", \"params\": { \"models\":\"Order\" } }";

    }
}