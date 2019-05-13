using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using static ClassForm.fc;
using System.Collections.Generic;
using DevExpress.DataAccess.Native.Sql;
using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.Parameters;

namespace HRMV02
{
    public partial class HRMV02R : DevExpress.XtraReports.UI.XtraReport
    {
        //List<DateTime> BA001List = new List<DateTime>();
        Dictionary<string,double> BA001List = new Dictionary<string, double>();
        List<XRTableCell> dayList = new List<XRTableCell>();
        List<XRTableCell> dayofweekList = new List<XRTableCell>();
        List<XRTableCell> workTimeList = new List<XRTableCell>();
        DateTime FDT = new DateTime();
        //List<string> FIDs = new List<string>();

        public HRMV02R(DateTime xDT)
        {
            InitializeComponent();
            FDT = xDT;
        }

        private void HRMV02R_ParametersRequestBeforeShow(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {


            /* dt.Properties.VistaCalendarViewStyle = VistaCalendarViewStyle.YearView;
            dt.Properties.DisplayFormat.FormatString = "yyyy/MM";
            dt.Properties.EditFormat.FormatString = "yyyy/MM";
            dt.Properties.Mask.EditMask = "yyyy/MM";
            dt.DateTime = DateTime.Now;
            e.ParametersInformation[0].Editor = dt; */

            dayList.AddRange(new List<XRTableCell>() {  lbDay1 ,lbDay2 ,lbDay3 ,lbDay4 ,lbDay5 ,
                                                        lbDay6 ,lbDay7 ,lbDay8 ,lbDay9 ,lbDay10,
                                                        lbDay11,lbDay12,lbDay13,lbDay14,lbDay15,
                                                        lbDay16,lbDay17,lbDay18,lbDay19,lbDay20,
                                                        lbDay21,lbDay22,lbDay23,lbDay24,lbDay25,
                                                        lbDay26,lbDay27,lbDay28,lbDay29,lbDay30,
                                                        lbDay31 });

            dayofweekList.AddRange(new List<XRTableCell>() {  lbDayOfWeek1 ,lbDayOfWeek2 ,lbDayOfWeek3 ,lbDayOfWeek4 ,lbDayOfWeek5 ,
                                                              lbDayOfWeek6 ,lbDayOfWeek7 ,lbDayOfWeek8 ,lbDayOfWeek9 ,lbDayOfWeek10,
                                                              lbDayOfWeek11,lbDayOfWeek12,lbDayOfWeek13,lbDayOfWeek14,lbDayOfWeek15,
                                                              lbDayOfWeek16,lbDayOfWeek17,lbDayOfWeek18,lbDayOfWeek19,lbDayOfWeek20,
                                                              lbDayOfWeek21,lbDayOfWeek22,lbDayOfWeek23,lbDayOfWeek24,lbDayOfWeek25,
                                                              lbDayOfWeek26,lbDayOfWeek27,lbDayOfWeek28,lbDayOfWeek29,lbDayOfWeek30,
                                                              lbDayOfWeek31 });

            workTimeList.AddRange(new List<XRTableCell>() {  lbWorkTime1 ,lbWorkTime2 ,lbWorkTime3 ,lbWorkTime4 ,lbWorkTime5 ,
                                                             lbWorkTime6 ,lbWorkTime7 ,lbWorkTime8 ,lbWorkTime9 ,lbWorkTime10,
                                                             lbWorkTime11,lbWorkTime12,lbWorkTime13,lbWorkTime14,lbWorkTime15,
                                                             lbWorkTime16,lbWorkTime17,lbWorkTime18,lbWorkTime19,lbWorkTime20,
                                                             lbWorkTime21,lbWorkTime22,lbWorkTime23,lbWorkTime24,lbWorkTime25,
                                                             lbWorkTime26,lbWorkTime27,lbWorkTime28,lbWorkTime29,lbWorkTime30,
                                                             lbWorkTime31 });

            try
            {
                BA001List.Clear();
                //DateEdit dt = (DateEdit)e.ParametersInformation[0].Editor;
                //DateEdit dt = new DateEdit();
                //DateTime mDate = DateTime.Parse(Parameters["Date"].Value.ToString());

                


                var tq = sqlDataSource1.Queries["Query_HRMBA"];
                tq.Parameters[0].Value = FDT.Year;
                tq.Parameters[1].Value = FDT.Month;
                sqlDataSource1.Fill();

                ResultSet rSet = (sqlDataSource1 as IListSource).GetList() as ResultSet;
                ResultTable categoriesTable = rSet["Query_HRMBA"];
                List<ResultColumn> resColBA001 = rSet["Query_HRMBA"].Columns.FindAll((col) => col.Name == "BA003" || col.Name == "BA005");
                for (int i = 0; i < categoriesTable.Count; i++)
                {
                    ResultRow rr = categoriesTable[i];
                    //BA001List.Add( DateTime.Parse(resColBA001.GetValue(rr).ToString()));
                    BA001List.Add(resColBA001[0].GetValue(rr).ToString(), double.Parse(resColBA001[1].GetValue(rr).ToString()));
                }

                var xlLDate = Controls["Detail"].Controls[$"xrLDate"];
                if (xlLDate != null)
                {
                    xlLDate.Text = $"{FDT.Year - 1911}年{FDT.Month.ToString().PadLeft(2, '0')}月";
                }

                int days = DateTime.DaysInMonth(FDT.Year, FDT.Month);

                bool isSPDay = false;
                for (int i = 0; i < 31; i++)
                {
                    if (i + 1 <= days)
                    {
                        DayOfWeek dow = new DateTime(FDT.Year, FDT.Month, i + 1).DayOfWeek;
                        string dowBig5 = GetDisplayDayOfWeek(dow);

                        foreach (var c in BA001List)
                        {
                            if (c.Key == (i + 1).ToString())
                            {
                                if (c.Value > 0)
                                {
                                    dayofweekList[i].ForeColor = Color.Red;
                                    dayList[i].ForeColor = Color.Red;
                                }
                                else
                                {
                                    dayofweekList[i].ForeColor = Color.Black;
                                    dayList[i].ForeColor = Color.Black;
                                }
                                isSPDay = true;
                                break;
                            }
                        }

                        if (!isSPDay)
                        {
                            if (dow == DayOfWeek.Sunday || dow == DayOfWeek.Saturday)
                            {
                                dayofweekList[i].ForeColor = Color.Red;
                                dayList[i].ForeColor = Color.Red;
                            }
                            else
                            {
                                dayofweekList[i].ForeColor = Color.Black;
                                dayList[i].ForeColor = Color.Black;
                            }
                        }
                        workTimeList[i].Text = "        時       分至        時       分";
                        dayofweekList[i].Text = dowBig5;
                        dayList[i].Text = $"{i + 1}";
                        isSPDay = false;
                    }
                    else
                    {
                        workTimeList[i].Text = "";
                        dayofweekList[i].Text = "";
                        dayList[i].Text = "";
                    }

                }

            }
            catch (Exception ex)
            {
                Msg(ex.Message, "錯誤");
            }
        }

        private void HRMV02R_ParametersRequestSubmit(object sender, DevExpress.XtraReports.Parameters.ParametersRequestEventArgs e)
        {

            try
            {
                BA001List.Clear();
                DateEdit dt = (DateEdit)e.ParametersInformation[0].Editor;
                //DateTime mDate = DateTime.Parse(Parameters["Date"].Value.ToString());
                             
                var tq = sqlDataSource1.Queries["Query_HRMBA"];
                tq.Parameters[0].Value = dt.DateTime.Year;
                tq.Parameters[1].Value = dt.DateTime.Month;
                sqlDataSource1.Fill();

                ResultSet rSet = (sqlDataSource1 as IListSource).GetList() as ResultSet;
                ResultTable categoriesTable = rSet["Query_HRMBA"];
                List<ResultColumn> resColBA001 = rSet["Query_HRMBA"].Columns.FindAll((col) => col.Name == "BA003" || col.Name == "BA005");
                for (int i = 0; i < categoriesTable.Count; i++)
                {
                    ResultRow rr = categoriesTable[i];
                    //BA001List.Add( DateTime.Parse(resColBA001.GetValue(rr).ToString()));
                    BA001List.Add(resColBA001[0].GetValue(rr).ToString(), double.Parse(resColBA001[1].GetValue(rr).ToString()));
                }

                var xlLDate = Controls["Detail"].Controls[$"xrLDate"];
                if (xlLDate != null)
                {
                    xlLDate.Text = $"{dt.DateTime.Year-1911}年{dt.DateTime.Month.ToString().PadLeft(2,'0')}月";
                }

                int days = DateTime.DaysInMonth(dt.DateTime.Year, dt.DateTime.Month);

                bool isSPDay = false;
                for(int i=0;i< 31; i++)                
                {
                    if (i + 1 <= days)
                    {
                        DayOfWeek dow = new DateTime(dt.DateTime.Year, dt.DateTime.Month, i+1).DayOfWeek;
                        string dowBig5 = GetDisplayDayOfWeek(dow);

                        foreach (var c in BA001List)
                        {
                            if (c.Key == (i + 1).ToString())
                            {
                                if (c.Value > 0)
                                {
                                    dayofweekList[i].ForeColor = Color.Red;
                                    dayList[i].ForeColor = Color.Red;                                    
                                }
                                else
                                {
                                    dayofweekList[i].ForeColor = Color.Black;
                                    dayList[i].ForeColor = Color.Black;
                                }
                                isSPDay = true;
                                break;
                            }
                        }

                        if (!isSPDay)
                        {
                            if (dow == DayOfWeek.Sunday || dow == DayOfWeek.Saturday)
                            {
                                dayofweekList[i].ForeColor = Color.Red;
                                dayList[i].ForeColor = Color.Red;
                            }
                            else
                            {
                                dayofweekList[i].ForeColor = Color.Black;
                                dayList[i].ForeColor = Color.Black;
                            }
                        }
                        workTimeList[i].Text = "        時       分至        時       分";
                        dayofweekList[i].Text = dowBig5;
                        dayList[i].Text = $"{i+1}";
                        isSPDay = false;
                    }
                    else
                    {
                        workTimeList[i].Text = "";
                        dayofweekList[i].Text = "";
                        dayList[i].Text = "";
                    }


                    /*var d = Controls["Detail"].Controls[$"xrT{i}"].Controls[0].Controls[0];
                    var w = Controls["Detail"].Controls[$"xrT{i}"].Controls[0].Controls[1];
                    if (w != null)
                    {
                        DayOfWeek dow = new DateTime(dt.DateTime.Year, dt.DateTime.Month, i).DayOfWeek;
                        string dowBig5 = GetDisplayDayOfWeek(dow);
                        ((XRTableCell)w).Text = dowBig5;

                        if (dow == DayOfWeek.Sunday || dow == DayOfWeek.Saturday)
                        {
                            ((XRTableCell)w).ForeColor = Color.Red;
                            isVacation = true;
                        }
                    }
                    if (d != null)
                    {
                        ((XRTableCell)d).Text = i.ToString();
                        if (isVacation)
                        {
                            ((XRTableCell)d).ForeColor = Color.Red;
                        }
                    }*/
                    //isVacation = false;
                }
            }
            catch(Exception ex)
            {
                Msg(ex.Message, "錯誤");
            }
        }


        private string GetDisplayDayOfWeek(DayOfWeek dow)
        {
            string resutlt = "";
            switch(dow)
            {
                case DayOfWeek.Sunday:
                    resutlt = "日";
                    break;
                case DayOfWeek.Monday:
                    resutlt = "一";
                    break;
                case DayOfWeek.Tuesday:
                    resutlt = "二";
                    break;
                case DayOfWeek.Wednesday:
                    resutlt = "三";
                    break;
                case DayOfWeek.Thursday:
                    resutlt = "四";
                    break;
                case DayOfWeek.Friday:
                    resutlt = "五";
                    break;
                case DayOfWeek.Saturday:
                    resutlt = "六";
                    break;
            }

            return resutlt;
        }
    }
}
