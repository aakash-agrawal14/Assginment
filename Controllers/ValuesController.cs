using ApiAssignment.Contract_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        string Base_Api_Endpoint = "https://testapi.donatekart.com/api/campaign";
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCampaignList()
        {
            try 
            {
                List<ApiBaseModel> model = new List<ApiBaseModel>();
                List<CampaignsResponse> ResponseModel = new List<CampaignsResponse>();
                var client = new RestClient(Base_Api_Endpoint);
                var request = new RestRequest(Method.GET);
                var response = await client.ExecuteAsync<List<ApiBaseModel>>(request);
                foreach (var res in response.Data)
                {
                    CampaignsResponse m = new CampaignsResponse
                    {
                        title = res.title,
                        totalAmount = res.totalAmount,
                        backersCount = res.backersCount,
                        endDate = res.endDate
                    };
                    ResponseModel.Add(m);
                }
                return Ok(ResponseModel);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }            
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ActiveCampaigns()
        {
            try
            {
                List<ApiBaseModel> model = new List<ApiBaseModel>();
                List<ActiveCampaignsResponse> ResponseModel = new List<ActiveCampaignsResponse>();
                var client = new RestClient(Base_Api_Endpoint);
                var request = new RestRequest(Method.GET);
                var response = await client.ExecuteAsync<List<ApiBaseModel>>(request);               
                var before30DaysDate = DateTime.Now.AddDays(-30);
                foreach (var res in response.Data)
                {
                    if (res.endDate >= before30DaysDate && res.endDate <= DateTime.Now) 
                    {
                        ActiveCampaignsResponse m = new ActiveCampaignsResponse
                        {
                            title = res.title,
                            endDate = res.endDate,
                            Status = "Active"                            
                        };
                        ResponseModel.Add(m);
                    }                  
                }            
                return Ok(ResponseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ClosedCampaigns()
        {
            try
            {
                List<ApiBaseModel> model = new List<ApiBaseModel>();
                List<ClosedCampaignsResponse> ResponseModel = new List<ClosedCampaignsResponse>();
                var client = new RestClient(Base_Api_Endpoint);
                var request = new RestRequest(Method.GET);
                var response = await client.ExecuteAsync<List<ApiBaseModel>>(request);
                model = response.Data.Where(x => x.endDate.Date <= DateTime.Now || x.procuredAmount >= x.totalAmount).ToList();
                foreach (var res in model)
                {
                    ClosedCampaignsResponse m = new ClosedCampaignsResponse
                    {
                        title = res.title,
                        totalAmount = res.totalAmount,
                        procuredAmount = res.procuredAmount,
                        endDate = res.endDate
                    };
                    ResponseModel.Add(m);
                }
                return Ok(ResponseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
