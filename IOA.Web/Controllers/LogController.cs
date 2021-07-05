using IOA.IRepository;
using IOA.Model;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOA.Web.Controllers
{
    public class LogController : Controller
    {
        ILoginLogRepository loginLog;

        public LogController(ILoginLogRepository _loginLog)
        {
            loginLog = _loginLog;
        }

        //显示登录日志信息表
        public IActionResult LoginLog()
        {
            return View();
        }


        //显示登录日志方法
        public IActionResult LoginLogIndex(string userName = "", int page = 1, int limit = 5)
        {
            List<LoginLog> loginLogs = loginLog.Show("select * from LoginLog", "");
            //查询语句  根据用户名进行查询
            if (!string.IsNullOrEmpty(userName))
            {
                loginLogs = loginLogs.Where(x => x.LoginName.Contains(userName)).ToList();
            }
            else
            {
                loginLogs = loginLogs.ToList();
            }
            //分页
            var pageData = loginLogs.Skip(limit * (page - 1)).Take(limit).ToList();

            return Ok(new { code = 0, msg = "", count = loginLogs.Count, data = pageData });
        }

        //删除日志信息
        public int DelLog(string id)
        {
            //定义字符数组保存截取之后的Id
            string[] strId = id.Split(',');
            //定义标识符
            int hang = 0;
            //循环执行删除
            foreach (var item in strId)
            {
                hang = loginLog.ZSG("delete from LoginLog where LoginId in(@ID)", new { @ID = item });
            }
            //返回1成功0失败
            return hang;
        }

        //导出日志信息
        public IActionResult ExportLogExcel()
        {
            ///获取所有日志信息
            List<LoginLog> loginLogs = loginLog.Show("select * from LoginLog", "");
            //生成一个工作簿
            IWorkbook wk = WorkbookFactory.Create(Directory.GetCurrentDirectory() + "/wwwroot/Files/登录日志.xlsx");
            //生成一个工作表
            ISheet sheet = wk.GetSheetAt(0);
            //循环数据
            for (int i = 0; i < loginLogs.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                //创建8个单元格
                for (int j = 0; j < 8; j++)
                {
                    row.CreateCell(j);
                }
                row.Cells[0].SetCellValue(loginLogs[i].LoginId);
                row.Cells[1].SetCellValue(loginLogs[i].LoginNo);
                row.Cells[2].SetCellValue(loginLogs[i].LoginDate);
                row.Cells[3].SetCellValue(loginLogs[i].LoginName);
                row.Cells[4].SetCellValue(loginLogs[i].LoginStatus);
                row.Cells[5].SetCellValue(loginLogs[i].LoginTerminal);
                row.Cells[6].SetCellValue(loginLogs[i].LoginIP);
                row.Cells[7].SetCellValue(loginLogs[i].LoginMAC);
            }
            //生成文件流（下载）
            MemoryStream memoryStream = new MemoryStream();
            wk.Write(memoryStream);
            return File(memoryStream.ToArray(), "application/ms-excel", $"登录日志{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx");
        }

    }

}
