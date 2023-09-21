using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Exception;
using project.Models;
using project.Models.Data_Transfer_Object;
using project.Services;
using System;

namespace project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
      
        private readonly DbService _listService;

        public DoorController()
        {
            _listService = new DbService();
        }

        //Add 

        [HttpPost]
        public Response Add(DoorDto Add_doorDto)
        {
            return _listService.Add(Add_doorDto);
        }

        //GetAll

        [HttpGet]
        public List<Door> GetAll()
        {
            return _listService.GetAll();
        }


        //Update

        [HttpPut]

        public Response Update(DoorDto updateDoorDto)
        {

            return _listService.Update(updateDoorDto);

        }

        //Delete


        [HttpDelete]

        public Response Delete(int id)
        {

            return _listService.Delete(id);

        }

        // değer getirme ??

        [HttpGet]
        public Response GetById(int id)
        {
            return _listService.GetById(id);
        }
    }
}
