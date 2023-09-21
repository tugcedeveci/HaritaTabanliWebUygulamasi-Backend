using Microsoft.AspNetCore.Mvc;
using project.Exception;
using project.Models;
using project.Models.Data_Transfer_Object;

namespace project.Services
{
    public class ListService
    {
        private static readonly List<Door> _doorList = new List<Door>();
        private static Random _random = new Random();

        //Add
        [HttpPost]
        public Response Add(DoorDto Add_doorDto)
        {
            var response = new Response();
            try
            {
                var newDoor = new Door();
                bool flag = false;
                do
                {
                    Random randomId = new Random();
                    int targetId = randomId.Next(); // 1 ile 100 arasında rastgele bir ID seç
                    bool idExist = _doorList.Any(door => door.id == targetId); // Bu ID zaten listede var mı kontrol et
                    if (!idExist)
                    {
                        newDoor.id = targetId;
                        flag = false;
                    }
                } while (flag);

                newDoor.name = Add_doorDto.name;
                newDoor.x = Add_doorDto.x;
                newDoor.y = Add_doorDto.y;

                _doorList.Add(newDoor);
                response.Data = newDoor;

                response.IsSuccess = true;
            }
            catch (System.Exception exception)
            {
                response = new Response { Message = exception.Message };

            }
            return response;
        }

        //GetAll

        [HttpGet]
        public List<Door> GetAll()
        {
            var response = new Response();
            try
            {
                response.Data = _doorList;
                response.IsSuccess = true;
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;
            }
            return _doorList;
        }

        //Update

        [HttpPut]
        public Response Update(DoorDto updateDoorDto) // Door updateDoorDto
        {
            Response response = new Response();
            try
            {
                var old_door = _doorList.FirstOrDefault(e => e.id == updateDoorDto.id);
                if (old_door == null)
                {
                    response.Message = "bulunamadı";
                    return response;
                }
                
                //x ve y değerleri sabit
                old_door.x = updateDoorDto.x;
                old_door.y = updateDoorDto.y;
                old_door.name = updateDoorDto.name;

                response.Data = old_door;
                response.IsSuccess = true;

            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        //Delete
        [HttpDelete]
        public Response Delete(DoorDto deleteDoorDto)
        {
            Response response = new Response();
            try
            {
                var door = _doorList.FirstOrDefault(e => e.id == deleteDoorDto.id);
                if (door == null)
                {
                    response.Message = "bulunamadı";
                    return response;
                }
                response.Data = door;
                response.IsSuccess = true;

            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }

        // değer getirme ??

        [HttpGet]
        public Response GetById(DoorDto findDoorDto)
        {
            Response response = new Response();

            try
            {
                var deger = _doorList.Find(b => b.id == findDoorDto.id);
                if (deger == null)
                {
                    response.Message = "bulunamadı";
                    return response;
                }
                response.Data = deger;
                response.IsSuccess = true;
            }
            catch (System.Exception ex)
            {
                response.Message = ex.Message;

            }


            return response;
        }

    }
}
