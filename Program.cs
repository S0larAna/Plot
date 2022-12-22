using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using ZedGraph;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Plot
{
    public class Plot
    {
        public static CoordType XScaleYChartFraction { get; private set; }

        public static double f(double x, double a, double b)
        {
            return Math.Exp(a * x) * Math.Cos(b * x);
        }

        public static void DrawGraph(double xmin, double xmax, double a, double b, ZedGraphControl zdc)
        {
            GraphPane graphPane = zdc.GraphPane;
            graphPane.Title.Text="Plot";
            graphPane.CurveList.Clear();
            PointPairList nodes = new PointPairList();
            PointPairList maxValueV = new PointPairList();
            PointPairList minValueV = new PointPairList();
            PointPairList maxValueH = new PointPairList();
            PointPairList minValueH = new PointPairList();
            double xmaxV=xmin;
            double xminV=xmin;
            double maxV = f(xmin, a, b);
            double minV = maxV;
            for (double x = xmin; x < xmax; x += 0.01)
            {
                nodes.Add(x, f(x, a, b));
                if (f(x, a, b) > maxV) { maxV = f(x, a, b); xmaxV = x;}
                if (f(x, a, b) < minV) { minV = f(x, a, b); xminV = x; }
            }
            //vertical lines
            for (double y = minV; y <= maxV; y += 0.01)
            {
                minValueV.Add(xminV, y);
                maxValueV.Add(xmaxV, y);
            }
            //horizontal lines
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                minValueH.Add(x, minV);
                maxValueH.Add(x, maxV);
            }

            LineItem lineMaxV = graphPane.AddCurve("Maximum Value", maxValueV, Color.Red, SymbolType.None);
            LineItem lineMinV = graphPane.AddCurve("Minimum Value", minValueV, Color.Blue, SymbolType.None);
            LineItem lineMaxH = graphPane.AddCurve($"Maximum Value={maxV}", maxValueH, Color.Red, SymbolType.None) ;
            LineItem lineMinH = graphPane.AddCurve($"Minimum Value={minV}", minValueH, Color.Blue, SymbolType.None);
            lineMaxV.Line.Style = DashStyle.Dot;
            lineMinV.Line.Style = DashStyle.Dot;
            lineMaxH.Line.Style = DashStyle.Dot;
            lineMinH.Line.Style = DashStyle.Dot;
            LineItem curve = graphPane.AddCurve($"f(x) = e^(x{a})cos({b}x", nodes, Color.Black, SymbolType.None);
            zdc.AxisChange();
            zdc.Invalidate();

        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
