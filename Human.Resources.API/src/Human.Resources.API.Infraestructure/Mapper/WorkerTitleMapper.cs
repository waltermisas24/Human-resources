using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Infraestructure.Entities;

namespace Human.Resources.API.Infraestructure.Mapper
{
    public class WorkerTitleMapper
    {
        public static WorkerData MapEntityToData(WorkerEntity workerEntity)
        {
            WorkerData workerData = new WorkerData();

            workerData.WorkerId = workerEntity.Id.ToString();
            workerData.WorkerTitleName = workerEntity.WorkTitleInfo.WorkTitle;
            workerData.DateIn = workerEntity.WorkTitleInfo.DateIn;
            workerData.DateOut = workerEntity.WorkTitleInfo.DateOut;
            workerData.Reasson = workerEntity.WorkTitleInfo.Reason;

            return workerData;
        }
    }
}
