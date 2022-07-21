using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Infraestructure.Mapper
{
    public class WorkerMapper
    {
        public static List<WorkerEntity> MapToEntity(IEnumerable<WorkerData> workerData)
        {
            List<WorkerEntity> workerEntities = new List<WorkerEntity>();

            foreach (WorkerData data in workerData)
            {
                WorkerEntity workerEntity = new WorkerEntity();

                workerEntity.Id = data.Id;
                workerEntity.Name = data.WorkerName;
                workerEntity.LastName = data.WorkerLastName;
                workerEntity.Email = data.Email;
                workerEntity.PhoneNumber = data.PhoneNumber;
                workerEntity.WorkerStatus = data.WorkerStatus;

                workerEntity.WorkTitleInfo = new WorkTitleInfoEntity();
                workerEntity.WorkTitleInfo.WorkTitle = data.WorkerTitleName;
                workerEntity.WorkTitleInfo.DateIn = data.DateIn;
                workerEntity.WorkTitleInfo.DateOut = data.DateOut;
                workerEntity.WorkTitleInfo.Reason = data.Reasson;

                workerEntities.Add(workerEntity);
            }

            return workerEntities;
        }
    }
}
