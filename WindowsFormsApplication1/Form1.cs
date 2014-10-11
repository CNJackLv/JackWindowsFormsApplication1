using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyExtensionMethod;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Reflection;

namespace WindowsFormsApplication1
{
    //test
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            #region 扩展方法
            //************************扩展方法************************
            //string tempstr = "392305138@qq.com";
            //int count = tempstr.GetWordLenth();
            ////textBox1.Text = count.ToString();
            //textBox1.Text = tempstr.IsValidEmail().ToString();
            int a = 1;
            #endregion
            #region select、selectMany
            //************************select、selectMany************************
            ////DataContext context = new DataContext();

            //List<Bouquet> bouquets = new List<Bouquet>()
            //{
            //    new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
            //    new Bouquet{ Flowers = new List<string> { "tulip", "rose", "orchid" }},
            //    new Bouquet{ Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
            //    new Bouquet{ Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
            //};

            //// *********** Select ***********           
            //IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

            //// ********* SelectMany *********
            //IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

            //Console.WriteLine("Results by using Select():");
            //// Note the extra foreach loop here.
            //foreach (IEnumerable<String> collection in query1)
            //    foreach (string item in collection)
            //        textBox1.Text += item + ",";
            //result
            //sunflower,daisy,daffodil,larkspur,tulip,rose,orchid,gladiolis,lily,snapdragon,aster,protea,larkspur,lilac,iris,dahlia,

            //Console.WriteLine("/nResults by using SelectMany():");
            //foreach (string item in query2)
            //    textBox1.Text += item+",";
            //result
            //sunflower,daisy,daffodil,larkspur,tulip,rose,orchid,gladiolis,lily,snapdragon,aster,protea,larkspur,lilac,iris,dahlia,

            //IEnumerable<int[]> result = SelectManyDemo.Compute(1, 10, 13, 4);
            //foreach (int[] collection in result)
            //{
            //    foreach (int item in collection)
            //    {
            //        textBox1.Text = textBox1.Text + item + ",";
            //    }
            //}
            #endregion
            #region Aggregate
            //************************Aggregate************************
            //string Names = "aa,bb,cc,dd";
            //string[] name = Names.Split(',');
            //Enumerable.Repeat("aa", 3);
            //string newname=name.Aggregate((workingName,next)=>next+" "+workingName);
            //textBox1.Text = newname;
            //result:dd cc bb aa

            //result:10,1,1,1,9,2,1,1,8,3,1,1,7,4,1,1,6,5,1,1,8,2,2,1,7,3,2,1,6,4,2,1,5,5,2,1,6,3,3,1,5,4,3,1,4,4,4,1,7,2,2,2,6,3,2,2,5,4,2,2,5,3,3,2,4,4,3,2,4,3,3,3,
            #endregion
            #region DOM解析XML
            //************************DOM解析XML************************
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(@"E:\from jack-pc\KWS\KWS_sample\AJack\CancelPointExchange\CancelPointExchangeRequest.xml");
            //XmlNodeList xmlnodelist = xmlDoc.SelectNodes("/aa/bb");
            //foreach (XmlNode node in xmlnodelist)
            //{
            //    string card_no = node.SelectSingleNode("cc").InnerXml;
            //    textBox1.Text = textBox1.Text + card_no;
            //}
            #endregion
            #region Linq to XML
            //************************Linq to XML************************
            //XElement element = new XElement("root",
            //    new XElement("Employees",
            //        new XElement("Employee",
            //            new XAttribute("id", 1),
            //        new XElement("Name", "aaa"),
            //        new XElement("Title", "Mr"),
            //        new XElement("Sex", "M")
            //        )
            //        )
            //    );
            //IEnumerable<XNode> nodes = element.Element("Employees").Element("Employee").Element("Name").ElementsAfterSelf();
            //foreach (XNode node in nodes)
            //{
            //    textBox1.Text = textBox1.Text + (node.NodeType == XmlNodeType.Element ? (node as XElement).Value : "") + "|";
            //}

            //textBox1.Text = element.ToString();

            #endregion
            #region 流式处理XML文档(待补全)
            //************************流式处理XML文档************************
            #endregion

        }
        #endregion

        #region 流式处理XML文档函数
        static IEnumerable<XElement> StreamSalesOrders(string url)
        {
            using (XmlReader reader = XmlReader.Create(url))
            {
                XElement name = null;
                XElement order = null;

                reader.MoveToContent();

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "SalesPerson")
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Name")
                            {
                                name = XElement.ReadFrom(reader) as XElement;
                                //break;
                            }
                            //}
                            //while (reader.Read())
                            //{
                            if (reader.NodeType == XmlNodeType.EndElement)
                            {
                                break;
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Order")
                            {
                                order = XElement.ReadFrom(reader) as XElement;
                                if (order != null)
                                {
                                    XElement tempRoot = new XElement("tempRoot",
                                        new XElement(name)
                                        );
                                    tempRoot.Add(order);
                                    yield return order;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region button2_Click
        /// <summary>
        /// sql to xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataContext context = new DataContext(@"Data Source=10.1.2.249\sql2005;Initial Catalog=ECRS;Persist Security Info=True;User ID=sa;Password=$#@!;");
            Table<Title> title = context.GetTable<Title>();

            XElement element = new XElement("Titles",
                from t in title
                orderby t.Sort_ID
                select new XElement("title",
                    new XAttribute("titlecode", t.Code),
                    new XElement("Name", t.Name)
                    )
                );
            textBox1.Text = element.ToString();
        }
        #endregion
        #region Xmltosql_Click
        /// <summary>
        /// xmltosql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Xmltosql_Click(object sender, EventArgs e)
        {
            try
            {
                //需要增加事务处理
                CRSContext context = new CRSContext(@"Data Source=10.1.2.249\sql2005;Initial Catalog=ECRS;Persist Security Info=True;User ID=sa;Password=$#@!;");
                XElement element = XElement.Load(@"C:\Users\jack\Desktop\1.xml");
                //insert
                //foreach (XElement xel in element.Elements("title"))
                //{
                //    Title title = new Title();
                //    title.Code = (string)xel.Element("Code");
                //    title.Name = (string)xel.Element("Name");

                //    //context.Log = Console.Out;
                //    context.Title.InsertOnSubmit(title);
                //    context.SubmitChanges();
                //}
                //update
                var update_title = context.Title.Single(c => c.Code == "qq");
                update_title.Sort_ID = 4;
                context.SubmitChanges();

                //delete
                var del_title = context.Title.Single(c => c.Code == "a");
                context.Title.DeleteOnSubmit(del_title);
                context.SubmitChanges();
            }
            catch (Exception exp)
            {
                textBox1.Text = exp.Message;
                //throw new Exception("Insert Failed");
            }

        }
        #endregion
        #region 流式处理XML文档_Click
        private void 流式处理XML文档_Click(object sender, EventArgs e)
        {
            XElement xmlTree = new XElement("Sales",
                from el in Form1.StreamSalesOrders(@"C:\Users\jack\Desktop\1.xml")
                where (int)el.Element("Amount") > 888
                select new XElement("Order",
                    new XElement(el.Parent.Element("Name")),
                    new XElement(el.Element("Amount"))
                    )
                );
            textBox1.Text = xmlTree.ToString();
        }
        #endregion
        #region yield_demo_Click
        private void yield_demo_Click(object sender, EventArgs e)
        {
            // Display powers of 2 up to the exponent 8:
            foreach (int i in ListTest.Power(2, 8))
            {
                //Console.Write("{0} ", i);
                textBox1.Text += i;
            }
        }
        #endregion
        #region 映射存储过程_Click
        private void 映射存储过程_Click(object sender, EventArgs e)
        {
            CRSContext context = new CRSContext(@"Data Source=10.1.2.249\sql2005;Initial Catalog=ECRS;Persist Security Info=True;User ID=sa;Password=$#@!;");
            //IEnumerable<DiscountByRule> result= context.GetDiscountByRule("12",'g001','001','001',3,'0',DateTime.Now);

            #region 映射sp之单一结果集
            ISingleResult<DiscountByRule> result = context.GetDiscountByRule("12", "SVCARD", "T011", "0099", 3, "0");
            foreach (DiscountByRule discount in result)
            {
                textBox1.Text = "Disc_food=" + discount.Disc_food + "Disc_beve=" + discount.Disc_beve + "Disc_misc=" + discount.Disc_misc;
            }
            #endregion
            #region 映射sp之标量返回
            int count = context.Customers_Count_By_Region("WA");
            Console.WriteLine(count);
            #endregion
            #region 映射sp之多个可能形状的单一结果集
            //分别返回各自的结果集合，如下：
            //返回全部Customer结果集
            IMultipleResults result_multi = context.Whole_Or_Partial_Customers_Set(1);
            IEnumerable<WholeCustomersSetResult> shape1 =
             result_multi.GetResult<WholeCustomersSetResult>();
            foreach (WholeCustomersSetResult compName in shape1)
            {
                Console.WriteLine(compName.CompanyName);
            }
            //返回部分Customer结果集
            result_multi = context.Whole_Or_Partial_Customers_Set(2);
            IEnumerable<PartialCustomersSetResult> shape2 =
             result_multi.GetResult<PartialCustomersSetResult>();
            foreach (PartialCustomersSetResult con in shape2)
            {
                Console.WriteLine(con.ContactName);
            }
            #endregion
            #region 映射sp之多个结果集
            IMultipleResults multi_result = context.Get_Customer_And_Orders("SEVES");
            //返回Customer结果集
            IEnumerable<CustomerResultSet> customer =
            multi_result.GetResult<CustomerResultSet>();
            //返回Orders结果集
            IEnumerable<OrdersResultSet> orders =
             multi_result.GetResult<OrdersResultSet>();
            //在这里，我们读取CustomerResultSet中的数据
            foreach (CustomerResultSet cust in customer)
            {
                Console.WriteLine(cust.CustomerID);
            }
            #endregion
            #region 映射sp之带输出参数
            //我们使用下面的语句调用此存储过程：注意：输出参数是按引用传递的，以支持参数为“in/out”的方案。在这种情况下，参数仅为“out”
            decimal? totalSales = 0;
            string customerID = "ALFKI";
            context.CustOrderTotal(customerID, ref totalSales);
            Console.WriteLine("Total Sales for Customer '{0}' = {1:C}",
            customerID, totalSales);
            #endregion
        }

        #endregion
        #region EntitySetDemo_Click
        private void EntitySetDemo_Click(object sender, EventArgs e)
        {
            CRSContext context = new CRSContext(@"Data Source=10.1.2.249\sql2005;Initial Catalog=ECRS;Persist Security Info=True;User ID=sa;Password=$#@!;");
            var EntitySetResult =
                from ship in context.Membership
                from info in context.Memberinfo
                where ship.code == "g001"
                select new { ship.name, info.chname };
            //IQueryable<Membership> EntitySetResult =
            //    from ship in context.Membership
            //    where ship.MemberInfo.FirstOrDefault().gh_no == ""
            //    select new { ship.code, ship.name };

            //foreach (IQueryable t in EntitySetResult)
            //{
                
            //}
        }
        #endregion
    }

    #region 数据模型定义
    [Table(Name = "dic_title")]
    public class Title
    {
        [Column(DbType = "Varchar(20) not null", IsPrimaryKey = true)]
        public string Code;
        [Column(DbType = "Varchar(1000) null")]
        public string Name;
        [Column(DbType = "int null")]
        public int? Sort_ID;
    }
    #endregion

    #region DataContext
    //强类型的DataContext
    public class CRSContext : DataContext
    {
        public CRSContext(string connstr) : base(connstr) { }
        //强类型的数据表
        public Table<Title> Title;
        public Table<MemberInfo> Memberinfo;
        public Table<Membership> Membership;

        #region 映射sp之单一结果集
        [Function(Name = "dbo.[sp_get_discount_by_rule]")]
        //?参数首位必须要定义为和sp中一致才可以吗
        public ISingleResult<DiscountByRule> GetDiscountByRule([Parameter(DbType = "varchar(4)")] string @his_type, [Parameter(DbType = "varchar(20)")] string Membership, [Parameter(DbType = "varchar(200)")] string Place, [Parameter(DbType = "varchar(200)")] string Source, [Parameter(DbType = "int")] int Person, [Parameter(DbType = "varchar(20)")] string @card_level)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), @his_type, Membership, Place, Source, Person, @card_level);
            return ((ISingleResult<DiscountByRule>)(result.ReturnValue));
        }
        #endregion
        #region 映射sp之标量返回
        [Function(Name = "dbo.[存储过程名字]")]
        public int Customers_Count_By_Region([Parameter
        (DbType = "NVarChar(15)")] string param1)
        {
            IExecuteResult result = this.ExecuteMethodCall(this,
            ((MethodInfo)(MethodInfo.GetCurrentMethod())), param1);
            return ((int)(result.ReturnValue));
        }
        #endregion
        #region 映射sp之多个可能形状的单一结果集
        /*
         数据库中的存储过程如下：
         ALTER PROCEDURE [dbo].[SingleRowset_MultiShape]
         -- Add the parameters for the stored procedure here
         (@param1 int )
        AS
        BEGIN
             -- SET NOCOUNT ON added to prevent extra result sets from
             -- interfering with SELECT statements.
             SET NOCOUNT ON;
             if(@param1 = 1)
             SELECT * from Customers as c where c.Region = 'WA'
             else if (@param1 = 2)
             SELECT CustomerID, ContactName, CompanyName from 
             Customers as c where c.Region = 'WA'
        END
         */
        [Function(Name = "dbo.[Whole Or Partial Customers Set]")]
        [ResultType(typeof(WholeCustomersSetResult))]
        [ResultType(typeof(PartialCustomersSetResult))]
        public IMultipleResults Whole_Or_Partial_Customers_Set([Parameter
        (DbType = "Int")] System.Nullable<int> param1)
        {
            IExecuteResult result = this.ExecuteMethodCall(this,
            ((MethodInfo)(MethodInfo.GetCurrentMethod())), param1);
            return ((IMultipleResults)(result.ReturnValue));
        }

        //我们分别定义了两个分部类，用于指定返回的类型。WholeCustomersSetResult类和PartialCustomersSetResult类，定义放在了下方
        #endregion
        #region 映射sp之多个结果集
        //这种存储过程可以生成多个结果形状，但我们已经知道结果的返回顺序。 
        //下面是一个按顺序返回多个结果集的存储过程Get Customer And Orders。 返回顾客ID为"SEVES"的顾客和他们所有的订单。
        /*
         * 数据库中sp如下：
         ALTER PROCEDURE [dbo].[Get Customer And Orders]
        (@CustomerID nchar(5))
            -- Add the parameters for the stored procedure here
        AS
        BEGIN
            -- SET NOCOUNT ON added to prevent extra result sets from
            -- interfering with SELECT statements.
            SET NOCOUNT ON;
            SELECT * FROM Customers AS c WHERE c.CustomerID = @CustomerID  
            SELECT * FROM Orders AS o WHERE o.CustomerID = @CustomerID
        END
         */
        [Function(Name = "dbo.[Get Customer And Orders]")]
        [ResultType(typeof(CustomerResultSet))]
        [ResultType(typeof(OrdersResultSet))]
        public IMultipleResults Get_Customer_And_Orders
        ([Parameter(Name = "CustomerID", DbType = "NChar(5)")]
string customerID)
        {
            IExecuteResult result = this.ExecuteMethodCall(this,
            ((MethodInfo)(MethodInfo.GetCurrentMethod())), customerID);
            return ((IMultipleResults)(result.ReturnValue));
        }
        //同样，自己手写类，让其存储过程返回各自的结果集:CustomerResultSet类和OrdersResultSet类，写在下方
        #endregion
        #region 映射sp之带输出参数
        /*
         LINQ to SQL 将输出参数映射到引用参数，并且对于值类型，它将参数声明为可以为 null。
        下面的示例带有单个输入参数（客户 ID）并返回一个输出参数（该客户的总销售额）。 
         * 数据库中的sp如下：
            ALTER PROCEDURE [dbo].[CustOrderTotal] 
            @CustomerID nchar(5),
            @TotalSales money OUTPUT
            AS
            SELECT @TotalSales = SUM(OD.UNITPRICE*(1-OD.DISCOUNT) * OD.QUANTITY)
            FROM ORDERS O, "ORDER DETAILS" OD
            where O.CUSTOMERID = @CustomerID AND O.ORDERID = OD.ORDERID
         */
        [Function(Name = "dbo.CustOrderTotal")]
        public int CustOrderTotal(
        [Parameter(Name = "CustomerID", DbType = "NChar(5)")]string customerID,
        [Parameter(Name = "TotalSales", DbType = "Money")]
  ref System.Nullable<decimal> totalSales)
        {
            IExecuteResult result = this.ExecuteMethodCall(this,
            ((MethodInfo)(MethodInfo.GetCurrentMethod())),
            customerID, totalSales);
            totalSales = ((System.Nullable<decimal>)
            (result.GetParameterValue(1)));
            return ((int)(result.ReturnValue));
        }
        #endregion
    }

    #region 映射sp之单一结果集
    //从数据库中返回行集合，并包含用于筛选结果的输入参数。 当我们执行返回行集合的存储过程时，会用到结果类，它存储从存储过程中返回的结果。
    //[Table(Name = "sp_get_discount_by_rule")]
    public partial class DiscountByRule
    {
        private string _to_dt;
        //[Column(Name = "to_dt", Storage = "_to_dt", DbType = "varchar(20)")]
        public string To_dt
        {
            get { return _to_dt; }
            set
            {
                if (this._to_dt != value)
                    _to_dt = value;
            }
        }
        private decimal _disc_food;
        //[Column(Name = "disc_food", Storage = "_disc_food", DbType = "decimal(18,2)")]
        public decimal Disc_food
        {
            get { return _disc_food; }
            set
            {
                if (this._disc_food != value)
                    _disc_food = value;
            }
        }
        private decimal _disc_beve;
        //[Column(Name = "disc_beve", Storage = "_disc_beve", DbType = "decimal(18,2)")]
        public decimal Disc_beve
        {
            get { return _disc_beve; }
            set
            {
                if (this._disc_beve != value)
                    _disc_beve = value;
            }
        }
        private decimal _disc_misc;
        //[Column(Name = "disc_misc", Storage = "_disc_misc", DbType = "decimal(18,2)")]
        public decimal Disc_misc
        {
            get { return _disc_misc; }
            set
            {
                if (this._disc_misc != value)
                    _disc_misc = value;
            }
        }
    }
    #endregion
    //非强类型的DataContext和非强类型的数据表
    //DataContext contextdemo = new DataContext("");
    //Table<Title> title = contextdemo.GetTable<Title>();
    #region class WholeCustomersSetResult
    public partial class WholeCustomersSetResult
    {
        private string _CustomerID;
        private string _CompanyName;
        private string _ContactName;
        private string _ContactTitle;
        private string _Address;
        private string _City;
        private string _Region;
        private string _PostalCode;
        private string _Country;
        private string _Phone;
        private string _Fax;
        public WholeCustomersSetResult()
        {
        }
        [Column(Storage = "_CustomerID", DbType = "NChar(5)")]
        public string CustomerID
        {
            get { return this._CustomerID; }
            set
            {
                if ((this._CustomerID != value))
                    this._CustomerID = value;
            }
        }
        [Column(Storage = "_CompanyName", DbType = "NVarChar(40)")]
        public string CompanyName
        {
            get { return this._CompanyName; }
            set
            {
                if ((this._CompanyName != value))
                    this._CompanyName = value;
            }
        }
        [Column(Storage = "_ContactName", DbType = "NVarChar(30)")]
        public string ContactName
        {
            get { return this._ContactName; }
            set
            {
                if ((this._ContactName != value))
                    this._ContactName = value;
            }
        }
        [Column(Storage = "_ContactTitle", DbType = "NVarChar(30)")]
        public string ContactTitle
        {
            get { return this._ContactTitle; }
            set
            {
                if ((this._ContactTitle != value))
                    this._ContactTitle = value;
            }
        }
        [Column(Storage = "_Address", DbType = "NVarChar(60)")]
        public string Address
        {
            get { return this._Address; }
            set
            {
                if ((this._Address != value))
                    this._Address = value;
            }
        }
        [Column(Storage = "_City", DbType = "NVarChar(15)")]
        public string City
        {
            get { return this._City; }
            set
            {
                if ((this._City != value))
                    this._City = value;
            }
        }
        [Column(Storage = "_Region", DbType = "NVarChar(15)")]
        public string Region
        {
            get { return this._Region; }
            set
            {
                if ((this._Region != value))
                    this._Region = value;
            }
        }
        [Column(Storage = "_PostalCode", DbType = "NVarChar(10)")]
        public string PostalCode
        {
            get { return this._PostalCode; }
            set
            {
                if ((this._PostalCode != value))
                    this._PostalCode = value;
            }
        }
        [Column(Storage = "_Country", DbType = "NVarChar(15)")]
        public string Country
        {
            get { return this._Country; }
            set
            {
                if ((this._Country != value))
                    this._Country = value;
            }
        }
        [Column(Storage = "_Phone", DbType = "NVarChar(24)")]
        public string Phone
        {
            get { return this._Phone; }
            set
            {
                if ((this._Phone != value))
                    this._Phone = value;
            }
        }
        [Column(Storage = "_Fax", DbType = "NVarChar(24)")]
        public string Fax
        {
            get { return this._Fax; }
            set
            {
                if ((this._Fax != value))
                    this._Fax = value;
            }
        }
    }
    #endregion
    #region class PartialCustomersSetResult
    public partial class PartialCustomersSetResult
    {
        private string _CustomerID;
        private string _ContactName;
        private string _CompanyName;
        public PartialCustomersSetResult()
        {
        }
        [Column(Storage = "_CustomerID", DbType = "NChar(5)")]
        public string CustomerID
        {
            get { return this._CustomerID; }
            set
            {
                if ((this._CustomerID != value))
                    this._CustomerID = value;
            }
        }
        [Column(Storage = "_ContactName", DbType = "NVarChar(30)")]
        public string ContactName
        {
            get { return this._ContactName; }
            set
            {
                if ((this._ContactName != value))
                    this._ContactName = value;
            }
        }
        [Column(Storage = "_CompanyName", DbType = "NVarChar(40)")]
        public string CompanyName
        {
            get { return this._CompanyName; }
            set
            {
                if ((this._CompanyName != value))
                    this._CompanyName = value;
            }
        }
    }
    #endregion
    #region class CustomerResultSet
    public partial class CustomerResultSet
    {

        private string _CustomerID;
        private string _CompanyName;
        private string _ContactName;
        private string _ContactTitle;
        private string _Address;
        private string _City;
        private string _Region;
        private string _PostalCode;
        private string _Country;
        private string _Phone;
        private string _Fax;
        public CustomerResultSet()
        {
        }
        [Column(Storage = "_CustomerID", DbType = "NChar(5)")]
        public string CustomerID
        {
            get { return this._CustomerID; }
            set
            {
                if ((this._CustomerID != value))
                    this._CustomerID = value;
            }
        }
        [Column(Storage = "_CompanyName", DbType = "NVarChar(40)")]
        public string CompanyName
        {
            get { return this._CompanyName; }
            set
            {
                if ((this._CompanyName != value))
                    this._CompanyName = value;
            }
        }
        [Column(Storage = "_ContactName", DbType = "NVarChar(30)")]
        public string ContactName
        {
            get { return this._ContactName; }
            set
            {
                if ((this._ContactName != value))
                    this._ContactName = value;
            }
        }
        [Column(Storage = "_ContactTitle", DbType = "NVarChar(30)")]
        public string ContactTitle
        {
            get { return this._ContactTitle; }
            set
            {
                if ((this._ContactTitle != value))
                    this._ContactTitle = value;
            }
        }
        [Column(Storage = "_Address", DbType = "NVarChar(60)")]
        public string Address
        {
            get { return this._Address; }
            set
            {
                if ((this._Address != value))
                    this._Address = value;
            }
        }
        [Column(Storage = "_City", DbType = "NVarChar(15)")]
        public string City
        {
            get { return this._City; }
            set
            {
                if ((this._City != value))
                    this._City = value;
            }
        }
        [Column(Storage = "_Region", DbType = "NVarChar(15)")]
        public string Region
        {
            get { return this._Region; }
            set
            {
                if ((this._Region != value))
                    this._Region = value;
            }
        }
        [Column(Storage = "_PostalCode", DbType = "NVarChar(10)")]
        public string PostalCode
        {
            get { return this._PostalCode; }
            set
            {
                if ((this._PostalCode != value))
                    this._PostalCode = value;
            }
        }
        [Column(Storage = "_Country", DbType = "NVarChar(15)")]
        public string Country
        {
            get { return this._Country; }
            set
            {
                if ((this._Country != value))
                    this._Country = value;
            }
        }
        [Column(Storage = "_Phone", DbType = "NVarChar(24)")]
        public string Phone
        {
            get { return this._Phone; }
            set
            {
                if ((this._Phone != value))
                    this._Phone = value;
            }
        }

        [Column(Storage = "_Fax", DbType = "NVarChar(24)")]
        public string Fax
        {
            get { return this._Fax; }
            set
            {
                if ((this._Fax != value))
                    this._Fax = value;
            }
        }
    }
    #endregion
    #region class OrdersResultSet
    public partial class OrdersResultSet
    {
        private System.Nullable<int> _OrderID;
        private string _CustomerID;
        private System.Nullable<int> _EmployeeID;
        private System.Nullable<System.DateTime> _OrderDate;
        private System.Nullable<System.DateTime> _RequiredDate;
        private System.Nullable<System.DateTime> _ShippedDate;
        private System.Nullable<int> _ShipVia;
        private System.Nullable<decimal> _Freight;
        private string _ShipName;
        private string _ShipAddress;
        private string _ShipCity;
        private string _ShipRegion;
        private string _ShipPostalCode;
        private string _ShipCountry;
        public OrdersResultSet()
        {
        }
        [Column(Storage = "_OrderID", DbType = "Int")]
        public System.Nullable<int> OrderID
        {
            get { return this._OrderID; }
            set
            {
                if ((this._OrderID != value))
                    this._OrderID = value;
            }
        }
        [Column(Storage = "_CustomerID", DbType = "NChar(5)")]
        public string CustomerID
        {
            get { return this._CustomerID; }
            set
            {
                if ((this._CustomerID != value))
                    this._CustomerID = value;
            }
        }
        [Column(Storage = "_EmployeeID", DbType = "Int")]
        public System.Nullable<int> EmployeeID
        {
            get { return this._EmployeeID; }
            set
            {
                if ((this._EmployeeID != value))
                    this._EmployeeID = value;
            }
        }
        [Column(Storage = "_OrderDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> OrderDate
        {
            get { return this._OrderDate; }
            set
            {
                if ((this._OrderDate != value))
                    this._OrderDate = value;
            }
        }
        [Column(Storage = "_RequiredDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> RequiredDate
        {
            get { return this._RequiredDate; }
            set
            {
                if ((this._RequiredDate != value))
                    this._RequiredDate = value;
            }
        }
        [Column(Storage = "_ShippedDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ShippedDate
        {
            get { return this._ShippedDate; }
            set
            {
                if ((this._ShippedDate != value))
                    this._ShippedDate = value;
            }
        }
        [Column(Storage = "_ShipVia", DbType = "Int")]
        public System.Nullable<int> ShipVia
        {
            get { return this._ShipVia; }
            set
            {
                if ((this._ShipVia != value))
                    this._ShipVia = value;
            }
        }
        [Column(Storage = "_Freight", DbType = "Money")]
        public System.Nullable<decimal> Freight
        {
            get { return this._Freight; }
            set
            {
                if ((this._Freight != value))
                    this._Freight = value;
            }
        }
        [Column(Storage = "_ShipName", DbType = "NVarChar(40)")]
        public string ShipName
        {
            get { return this._ShipName; }
            set
            {
                if ((this._ShipName != value))
                    this._ShipName = value;
            }
        }
        [Column(Storage = "_ShipAddress", DbType = "NVarChar(60)")]
        public string ShipAddress
        {
            get { return this._ShipAddress; }
            set
            {
                if ((this._ShipAddress != value))
                    this._ShipAddress = value;
            }
        }
        [Column(Storage = "_ShipCity", DbType = "NVarChar(15)")]
        public string ShipCity
        {
            get { return this._ShipCity; }
            set
            {
                if ((this._ShipCity != value))
                    this._ShipCity = value;
            }
        }
        [Column(Storage = "_ShipRegion", DbType = "NVarChar(15)")]
        public string ShipRegion
        {
            get { return this._ShipRegion; }
            set
            {
                if ((this._ShipRegion != value))
                    this._ShipRegion = value;
            }
        }
        [Column(Storage = "_ShipPostalCode", DbType = "NVarChar(10)")]
        public string ShipPostalCode
        {
            get { return this._ShipPostalCode; }
            set
            {
                if ((this._ShipPostalCode != value))
                    this._ShipPostalCode = value;
            }
        }

        [Column(Storage = "_ShipCountry", DbType = "NVarChar(15)")]
        public string ShipCountry
        {
            get { return this._ShipCountry; }
            set
            {
                if ((this._ShipCountry != value))
                    this._ShipCountry = value;
            }
        }
    }
    #endregion
    #endregion
    #region class Bouquet
    class Bouquet
    {
        public List<string> Flowers { get; set; }
    }
    #endregion
    #region class SelectManyDemo
    class SelectManyDemo
    {
        /// 给出sum、min、max和n四个正整数，请输出所有将sum拆分为n个正整数之和，其中每个正整数k都满足：min <= k <= max。这n个正整数之间可以重复，不过由于加法交换率的作用，1 + 2和2 + 1便算是重复的拆分了。
        ///例如，sum = 5，n = 3，min = 1，max = 3，这时候满足条件的拆分方式只有两种：
        /// 1 + 1 + 3
        /// 1 + 2 + 2
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="sum"></param>
        /// <param name="count">n</param>
        /// <returns></returns>
        public static IEnumerable<int[]> Compute(int min, int max, int sum, int count)
        {
            var list = Enumerable.Range(min, max - min + 1);

            if (count == 1)
                return
                    from item
                        in list
                    where item == sum
                    select new int[] { item };

            return list.SelectMany
                (
                number => Compute(number, max, sum - number, count - 1).Select
                    (
                    item => item.Concat(new int[] { number }).ToArray()
                    )
                );
        }
    }
    #endregion

    
}
#region EntitySet和EntityRef Demo
[Table(Name="member_info_svc")]
public class MemberInfo
{
    [Column(DbType="varchar(255)",IsPrimaryKey=true)]
    public string gh_no;
    [Column(DbType="varchar(50)")]
    public string chname;
    [Column(DbType = "varchar(20)")]
    public string membership_type;

    
}

[Table(Name = "dic_card_membership")]
public class Membership
{
    [Column(DbType = "varchar(20)", IsPrimaryKey = true)]
    public string code;
    [Column(DbType = "varchar(50)")]
    public string name;

    private EntitySet<MemberInfo> _MemberInfo;
    [Association(Storage = "_MemberInfo)", OtherKey = "membership_type")]
    public EntitySet<MemberInfo> MemberInfo
    {
        get { return _MemberInfo; }
        set { this._MemberInfo.Assign(value); }
        //set { this._Membership=value; }
    }
}
#endregion
#region 扩展方法 : namespace MyExtensionMethod
//扩展方法
namespace MyExtensionMethod
{
    public static class MyExtensionMethod
    {
        public static int GetWordLenth(this System.String str)
        {
            return str.Split(null).Length;
        }

        public static bool IsValidEmail(this string email)
        {
            Regex exp = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w.]{2,4}$");
            return exp.IsMatch(email);
        }
    }
}
#endregion
#region yield example: class ListTest
/// <summary>
/// yield example
/// </summary>
public class ListTest
{
    public static IEnumerable Power(int number, int exponent)
    {
        int counter = 0;
        int result = 1;
        while (counter++ < exponent)
        {
            result = result * number;
            yield return result;
        }
    }
}
#endregion