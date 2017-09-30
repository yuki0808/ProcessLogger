using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProcessLogger
{

  public partial class Form1 : Form
  {

    private DatagridViewCheckBoxHeaderCell2 cbHeader = new DatagridViewCheckBoxHeaderCell2();
    ArrayList pList = new ArrayList();
    static Boolean loopFlg = true;
    //Thread thread;
    private string tempSec = "3";


    public Form1()
    {
      InitializeComponent();
      pList = getProcessList();

      generateProcessListDGV();
      this.dgvCB.HeaderCell = cbHeader;
      cbHeader.OnCheckBoxClicked += new CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);

      //foreach( string token in pList ){
      //  psCB.Items.Add(token);
      //}
    }

    private void cbHeader_OnCheckBoxClicked(bool state)
    {
      Boolean checkBool = false;

      if (cbHeader.isChecked())
      {
        checkBool = true;
        
      }
      else {
        checkBool = false;
      }

      foreach (DataGridViewRow dgvr in processDGV.Rows)
      {
        dgvr.Cells[0].Value = checkBool;
      }
    }


    private void button1_Click(object sender, EventArgs e)
    {

      //if(psCB.Text == ""){
      //  return;
      //}

      ArrayList pList = getCheckedPIDList();

      if(pList.Count == 0){
        return;
      }

      button1.Enabled = false;
      stopB.Enabled = true;
      string timeInterval = textBox1.Text;

      foreach(String token in pList){

        string pId = token;
        String[] param = { pId, timeInterval };

        Thread thread = new Thread(new ParameterizedThreadStart(loggingProcessInfo));
        thread.Start(param);
      }
    }

    private ArrayList getCheckedPIDList() {
      ArrayList result = new ArrayList();

      foreach (DataGridViewRow dgvr in processDGV.Rows)
      {
        if ((Boolean)dgvr.Cells[0].Value)
        {
          result.Add(dgvr.Cells[1].Value.ToString());
        }
      }
      return result;
    }


    private void loggingProcessInfo(Object obj)
    {

      //string pName = (string)obj;
      string[] param = (String[])obj;
      //string pName = param[0];
      loopFlg = true;

      //ProcessID版
      int pId = int.Parse(param[0]);
      int timeInterval = int.Parse(param[1])*1000;
      //int pid = int.Parse(param[2]);

      while (loopFlg)
      {
        //Process名版
        System.Diagnostics.Process ps = System.Diagnostics.Process.GetProcessById(pId);
       
        //ProcessID版 Start
        //System.Diagnostics.Process ps = System.Diagnostics.Process.GetProcessById(pid);
        //WriteTraceLog(ps.Id + "," + ps.ProcessName + "," + ps.TotalProcessorTime + "," + ps.PrivateMemorySize64);
        
        //ProcessID版 END
        Thread.Sleep(timeInterval);

        //Console.WriteLine(p.ProcessName + "," + p.TotalProcessorTime + "," + p.WorkingSet64);
        WriteTraceLog(ps.Id + "," + ps.ProcessName + "," + ps.TotalProcessorTime + "," + ps.PrivateMemorySize64, ps.Id.ToString());

      }


    }

    private static void WriteTraceLog(String msg, String pId)
    {
      WriteTraceLog(msg, pId, null);
    }


    private static void WriteTraceLog(String msg, String logSuffix, Exception ex)
    {
      try
      {
        // ログフォルダ名作成
        DateTime dt = DateTime.Now;
        String logFolder = System.AppDomain.CurrentDomain.BaseDirectory + "Log";

        // ログフォルダ名作成
        System.IO.Directory.CreateDirectory(logFolder);

        // ログファイル名作成
        String logFile = logFolder + "\\Process_" + logSuffix +".log";

        // 翌日分のログファイル削除(１ヶ月分のログファイルしか保存しないようにするため)
        //String logNext = logFolder + "\\TraceLog" + dt.AddDays(1).ToString("dd") + ".log";
        //System.IO.File.Delete(logNext);

        // ログ出力文字列作成
        String logStr;
        logStr = dt.ToString("yyyy/MM/dd") + "," + dt.ToString("HH:mm:ss") + "," + msg;
        if (ex != null)
        {
          logStr = logStr + "\n" + ex.ToString();
        }

        // Shift-JISでログ出力
        System.IO.StreamWriter sw = null;
        try
        {
          if (!File.Exists(logFile))
          {
            sw = new System.IO.StreamWriter(logFile, true,
                System.Text.Encoding.GetEncoding("Shift-JIS"));
            sw.WriteLine("Date,Time,ProcessID,ProcessName,TotalProcessorTime,PrivateMemSize");
          }

          sw = new System.IO.StreamWriter(logFile, true,
              System.Text.Encoding.GetEncoding("Shift-JIS"));
          sw.WriteLine(logStr);
        }
        catch { }
        finally
        {
          if (sw != null) sw.Close();
        }
      }
      catch { }
    }

    private ArrayList getProcessList() {

      ArrayList result = new ArrayList();

      System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses();

      foreach (System.Diagnostics.Process p in ps)
      {
        try
        {
          result.Add(p.ProcessName + " " + p.Id); 
        }
        catch (Exception ex)
        {
          MessageBox.Show("エラー: {0}", ex.Message);
        }
      }

      result.Sort();

      return result;
    }


    /// <summary>
    /// 
    /// </summary>
    private void generateProcessListDGV()
    {
      ManagementObjectSearcher query = new ManagementObjectSearcher(@"SELECT * FROM Win32_Process");
      ManagementObjectCollection col = query.Get();

        foreach (ManagementObject mo in col)
        {
          string pOwner = "";
          object[] UserInfo = new object[2];
          mo.InvokeMethod("GetOwner", UserInfo);
          pOwner = ((string)UserInfo[0]);

          processDGV.Rows.Add(false, mo["ProcessId"], mo["Name"], pOwner);
        }

      //foreach (System.Diagnostics.Process p in processes)
      //{
      //  //TODO
      //  ManagementObjectSearcher query = new ManagementObjectSearcher(@"SELECT * FROM Win32_Process Where ProcessId = '" + p.Id + "'");
      //  ManagementObjectCollection col = query.Get();
      //  string pOwner = "";


      //  //if(col.Count ==1){
      //  //  foreach (ManagementObject o in col)
      //  //  {
      //  //    object[] UserInfo = new object[2];
      //  //    o.InvokeMethod("GetOwner", UserInfo);
      //  //    pOwner = ((string)UserInfo[0]);
      //  //  }
      //  //}


      //  try
      //  {
      //    processDGV.Rows.Add(false, p.Id, p.ProcessName, pOwner);
      //  }
      //  catch (Exception ex) {
      //    Console.WriteLine("エラー: {0}", ex.Message);
      //  }


        //try
        //{
        //  result.Add(p.ProcessName + " " + p.Id);
        //}
        //catch (Exception ex)
        //{
        //  Console.WriteLine("エラー: {0}", ex.Message);
        //  WriteTraceLog("エラー: " + ex.Message);
        //}
      //}
    
    }






    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private Process[] getProcesses() {


      Process[] result = System.Diagnostics.Process.GetProcesses();

      return result;
    
    }


    private void refreshB_Click(object sender, EventArgs e)
    {

      //processDGV.Columns.Clear();
      do
      {
        foreach (DataGridViewRow r in processDGV.Rows)
        {
          processDGV.Rows.Remove(r);
        }
      } while (processDGV.Rows.Count > 0);


      generateProcessListDGV();

      //pList = getProcessList();

      //psCB.Items.Clear();

      //foreach (string token in pList)
      //{
      //  psCB.Items.Add(token);
      //}

    }

    private void stopB_Click(object sender, EventArgs e)
    {
      loopFlg = false;
      button1.Enabled = true;
      stopB.Enabled = false;
    }


    private string getProcessName(string target) {
      string result = "";

      int index = target.IndexOf(" ");


      result = target.Substring(0, index);

      return result;

    }

    private string getProcessId(string target)
    {
      string result = "";

      int index = target.IndexOf(" ");


      result = target.Substring(index);

      return result;

    }

    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
      {
        e.Handled = true;
      }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      loopFlg = false;
    }

    private void textBox1_Leave(object sender, EventArgs e)
    {
      if (textBox1.Text.Length == 0)
      {
        textBox1.Text = this.tempSec;
      
      }
    }

    private void textBox1_Enter(object sender, EventArgs e)
    {
      this.tempSec = textBox1.Text;
    }


    public delegate void CheckBoxClickedHandler(bool state);
    public class DataGridViewCheckBoxHeaderCellEventArgs : EventArgs
    {
      bool _bChecked;
      public DataGridViewCheckBoxHeaderCellEventArgs(bool bChecked)
      {
        _bChecked = bChecked;
      }
      public bool Checked
      {
        get { return _bChecked; }
      }
    }

  }
}
