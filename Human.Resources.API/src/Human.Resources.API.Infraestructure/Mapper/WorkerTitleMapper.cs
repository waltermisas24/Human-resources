using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Infraestructure.Mapper
{
    public class WorkerTitleMapper
    {
        public static WorkerData MapEntityToData(WorkerEntity workerEntity)
        {
            WorkerData workerData = new WorkerData();

            workerData.WorkerId = workerEntity.Id;
            workerData.WorkerTitleName = workerEntity.WorkTitleInfo.WorkTitle;
            workerData.DateIn = workerEntity.WorkTitleInfo.DateIn;
            workerData.DateOut = workerEntity.WorkTitleInfo.DateOut;
            workerData.Reasson = workerEntity.WorkTitleInfo.Reason;

            return workerData;
        }
    }
}
