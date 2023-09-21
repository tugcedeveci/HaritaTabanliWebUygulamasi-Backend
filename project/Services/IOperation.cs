using project.Exception;
using project.Models;
using project.Models.Data_Transfer_Object;

namespace project.Services
{
    public interface IOperations
    {
        Response Add(DoorDto Add_doorDto);
        Response Delete(int id);
        List<Door> GetAll();
        Response Update(DoorDto updateDoorDto);

        Response GetById(int id);
    }
}
