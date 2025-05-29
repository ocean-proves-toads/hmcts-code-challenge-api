using Xunit;
using Moq;
using TasksApi.Controllers;
using TasksApi.Entities;
using TasksApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TasksApi.Tests;

public class TasksControllerTests
{
    private readonly Mock<IMojTasksRepository> _mockRepo;
    private readonly MojTasksController _controller;


    public TasksControllerTests()
    {
        _mockRepo = new Mock<IMojTasksRepository>();
        _controller = new MojTasksController(_mockRepo.Object);
    }
    [Fact]
    public void Test1()
    {

    }
    [Fact]
    public async Task GetTasks_ReturnsOkResult_WithListOfTasks()
    {
        // Arrange
        var tasks = new List<MojTask>
        {
            new MojTask {TaskId = 1, TaskDescription = "Test Task 1", TaskStatus = "Open", TaskDueDate = new DateOnly(2025, 5, 15)},
            new MojTask {TaskId = 2, TaskDescription = "Test Task 2", TaskStatus = "Closed", TaskDueDate = new DateOnly(2025, 3, 10)}
        };

        _mockRepo.Setup(repo => repo.GetMojTasksAsync()).ReturnsAsync(tasks);

        // Act
        var result = await _controller.GetMojTasks();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnTasks = Assert.IsAssignableFrom<IEnumerable<MojTask>>(okResult.Value);
        Assert.Equal(2, ((List<MojTask>)returnTasks).Count);
    }

    [Fact]
    public async Task GetTask_ReturnsNotFound_WhenTaskDoesNotExist()
    {
        // Arrange
        _mockRepo.Setup(repo => repo.GetMojTaskAsync(1)).ReturnsAsync((MojTask)null);

        // Act
        var result = await _controller.GetMojTask(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task CreateTask_AddsTask()
    {
        // Arrange
        var newMojTask = new MojTask
        {
            TaskId = 3,
            TaskDescription = "Test Create Task",
            TaskStatus = "Open",
            TaskDueDate = new DateOnly(2025, 5, 15)
        };

        // Act
        await _controller.CreateMojTask(newMojTask);

        // Assert
        _mockRepo.Verify(repo => repo.CreateMojTask(It.Is<MojTask>(t => t.TaskDescription == "Test Create Task")), Times.Once);

    }

}
