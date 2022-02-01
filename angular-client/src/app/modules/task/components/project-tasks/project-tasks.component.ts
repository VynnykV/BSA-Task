import { Component, OnInit } from '@angular/core';
import {Task} from "../../../../models/task/task";
import {Subject, takeUntil} from "rxjs";
import {TaskService} from "../../../task/task.service";
import {ActivatedRoute} from "@angular/router";
import {TaskState} from "../../../../models/task/TaskState";

@Component({
  selector: 'app-project-tasks',
  templateUrl: './project-tasks.component.html',
  styleUrls: ['./project-tasks.component.css']
})
export class ProjectTasksComponent implements OnInit {

  public tasks: Task[] = [];
  public taskState = TaskState;
  public projectId!: number;

  private unsubscribe$ = new Subject<void>();

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.projectId = this.route.snapshot.params['id'];
    this.getTasks();
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }

  public getTasks() {
    this.taskService
      .getTasks()
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (resp) => {
          this.tasks = resp.filter(t=>t.project.id == this.projectId);
        }
      )
  }

  public deleteTask(id: number) {
    this.taskService
      .deleteTask(id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(() => {
        this.tasks = this.tasks.filter(t=>t.id !== id);
      })
  }

}
