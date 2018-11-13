using System;
using System.Collections.Generic;
using EFCodeFirst.EF;

namespace EFCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start.. \n");

            BuildData();

            Console.WriteLine("Please enter any key to close..");
            Console.ReadKey(true);
        }

        /// <summary>
        /// 造数据
        /// </summary>
        public static void BuildData()
        {
            int seed = new Random().Next(100000, 1000000);
            for (int i = 0; i < 10; i++)
            {
                seed++;
                List<Att> fjs = null;
                for (int j = 0; j < i; j++)
                {
                    fjs = fjs ?? new List<Att>();
                    fjs.Add(new Att() { Article_Id = seed.ToString(), FileName = null, Grabed = true, ShowName = null, CTime = DateTime.Now });
                };
                var ot = new Other() { Id = seed.ToString(), Title = null, Column = null, Content = null, Number = null, PublishDate = null, Type = null, URL = null, CTime = DateTime.Now };
                intodb(ot, fjs);
            }
        }

        public static void intodb(Other oer, List<Att> atts)
        {
            try
            {
                var context = new DefaultContext();
                context.Others.Add(oer);
                if (atts != null)
                {
                    atts.ForEach(e => { context.Atts.Add(e); });
                }
                int r = context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
