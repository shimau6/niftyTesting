using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webTopPage
{
    class ConnectException
    {
        List<ans> errorList = new List<ans>
        {
            new ans(0,400,"ID,Passwordが記入されていることを確認してください"),
            new ans(0,409,"IDが他のユーザーと重複しています。変更してください"),
            new ans(1,400,"ID,Passwordが記入されていることを確認してください"),
            new ans(1,401,"ID,Passwordを間違えています。入力しなおしてください"),
            new ans(2,401,"そもそもログインしてなくない？"),
            new ans(11,401,"ダウンロードしたいファイルの名前とパスワードを間違えています。入力しなおしてください")

        };

        public void showMessage(String message,int methodnum)
        {
            int response = 0;
            System.Text.RegularExpressions.MatchCollection mc =
            System.Text.RegularExpressions.Regex.Matches(
            message, @"\d\d\d");
            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                response = int.Parse(m.Value);
            }

            var mes = errorList.Find(x => x.methodNum == methodnum && x.errorVal == response);
            if (mes != null)
            {
                MyUtility.WARNING("エラーが発生しました:" + Environment.NewLine + mes.message);
            }
            else
            {
                MyUtility.WARNING("制作者が認知していないエラーです。エラーコード：" + response);
            }
        }
    }

    public class ans
    {
        public int methodNum;
        public int errorVal;
        public string message;

        public ans(int methodnum,int errorVal,string message){
            this.methodNum = methodnum;
            this.errorVal = errorVal;
            this.message = message;
        }
    }
}
