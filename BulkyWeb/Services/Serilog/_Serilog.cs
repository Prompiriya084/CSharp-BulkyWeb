using Microsoft.Data.SqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Services.Serilog
{
    public class _Serilog : _ISerilog
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _connectionString;
        private static string GetDatabaseNameFromConnectionString(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            return builder.InitialCatalog;
        }
        private static string GetServerNameFromConnectionString(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString);
            return builder.DataSource;
        }
        public _Serilog(IHttpContextAccessor httpContext, IConfiguration configuration)
        {
            _httpContextAccessor = httpContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        
        public string UserAndHost()
        {
            try
            {
                string controllerName = _httpContextAccessor.HttpContext.Request.RouteValues["controller"].ToString();
                string actionName = _httpContextAccessor.HttpContext.Request.RouteValues["action"].ToString();

                //string controllerName = _routeInfoServices.GetCurrentControllerName();
                //string actionName = _routeInfoServices.GetCurrentActionName();

                var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var userName = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                var userRole = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                //var userDevice = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "DeviceName")?.Value;
                //var userId = _routeInfoServices.GetCurrentClaimUser().Id;
                //var userName = _routeInfoServices.GetCurrentClaimUser().Name;
                //var userRole = _routeInfoServices.GetCurrentClaimUser().Role;

                string hostName = Dns.GetHostName();
                var database = GetDatabaseNameFromConnectionString(_connectionString);
                var dbserver = GetServerNameFromConnectionString(_connectionString);
                //string plant = _HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Plant")?.Value;
                //string hostName = _HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Host Name")?.Value;

                return $"CONTROLLER : {controllerName} | " +
                       $"ACTION : {actionName} | " +
                       $"DataBase : {database} ({dbserver}) | " +
                       //$"Server : {server} | " +
                       $"HOSTNAME : {hostName} " +
                       $"USERNAME : {userName} ({userId}) | " +
                       $"TIME : {DateTime.Now} | ";

                //$"DEVICENAME : {userDevice} ";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LogInformation(string message)
        {
            Log.Information(UserAndHost() + " | Detail: " + message);
        }
        public void LogNoMessage()
        {
            Log.Information(UserAndHost());
        }

        public void LogWarning(string message)
        {
            Log.Warning(UserAndHost() + " | " + message);
        }
        public void LogError(string message)
        {
            Log.Error(UserAndHost() + " | " + message);
        }
    }
}
