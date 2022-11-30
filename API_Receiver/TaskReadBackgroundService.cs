using API_Receiver.Models;

namespace API_Receiver
{
    public class TaskReadBackgroundService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken token)
        {
            // 1. onnect to Tasks Database
            var taskContext = new TasksContext();

            // 2 Read All Tasks
            var receivedTasks = taskContext.JobTasks.ToList();

            // 3. Connet to TasksReport Database
            var reportedTasksContext = new TasksReportContext();

            // 4. Read already reported Tasks

            var reportedTasks = reportedTasksContext.JobTaskNews.ToList();
            // 

            // 5. put all data from receivedTasks to Report Task
             
            
                foreach (var receiveTask in receivedTasks)
                 {
                if (reportedTasks.Count == 0)
                {
                    var record = new JobTaskNew()
                    {
                        //TaskId = receiveTask.TaskId,
                        TaskName = receiveTask.TaskName,
                        AssignedDate = receiveTask.AssignedDate,
                        AssignedTo = receiveTask.AssignedTo
                    };
                    reportedTasksContext.JobTaskNews.Add(record);
                    reportedTasksContext.SaveChanges();
                }
                else
                { 
                    foreach (var reportTask in reportedTasks)
                    {
                        if (reportTask.TaskId == receiveTask.TaskId)
                        {
                            continue;
                        }
                        else
                        {
                            var record = new JobTaskNew()
                            {
                               // TaskId = receiveTask.TaskId,
                                TaskName = receiveTask.TaskName,
                                AssignedDate = receiveTask.AssignedDate,
                                AssignedTo = receiveTask.AssignedTo
                            };
                            reportedTasksContext.JobTaskNews.Add(record);
                            reportedTasksContext.SaveChanges();
                        }

                    }
                }
            }

                
            
             

            return Task.CompletedTask;
        }
    }
}
