using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    private List<CalEvent> eventsThisMonth;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Repeater 1
        List<DateTime> month = new List<DateTime>();
        for(DateTime d = DateTime.Now.AddDays( - DateTime.Now.Day +1 ); 
            d.Month == DateTime.Now.Month ; 
            d=d.AddDays(1) )
        {
            month.Add(d);
        }
        RepeaterMonth1.DataSource = month;
        RepeaterMonth1.DataBind();

        // Andet forsøg
        // Repeater 2
        eventsThisMonth = new List<CalEvent>();
        using (calendarContext ctx = new calendarContext())
        {
            DateTime StartMonth = ((DateTime)DateTime.Now.AddDays(-DateTime.Now.Day));
            DateTime EndMonth = ((DateTime)DateTime.Now.AddDays(-DateTime.Now.Day).AddMonths(1));
            var events2 = ctx.CalEvents
                .Where(x => x.start_date > StartMonth
                            && x.start_date <= EndMonth);
            foreach (var cEvent in events2)
            {
                eventsThisMonth.Add(cEvent);
            }
            RepeaterMonth2.DataSource = month;
            RepeaterMonth2.DataBind();
        }

    }

    protected void RepeaterMonth1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        using (calendarContext ctx = new calendarContext())
        {
            var events = ctx.CalEvents
                        .Where(x => x.start_date == ((DateTime)e.Item.DataItem).Date)
                        .Select(ev => ev);

            Repeater RepeaterDay1 = ((Repeater)e.Item.FindControl("RepeaterDay1"));

            if (RepeaterDay1 != null)
            {
                RepeaterDay1.DataSource = events;
                RepeaterDay1.DataBind();
            }
        }
    }

    protected void RepeaterMonth2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        using (calendarContext ctx = new calendarContext())
        {
            var events = this.eventsThisMonth
                        .Where(x => x.start_date == ((DateTime)e.Item.DataItem).Date)
                        .Select(ev => ev);

            Repeater RepeaterDay2 = ((Repeater)e.Item.FindControl("RepeaterDay2"));

            if (RepeaterDay2 != null)
            {
                RepeaterDay2.DataSource = events;
                RepeaterDay2.DataBind();
            }
        }
    }

}