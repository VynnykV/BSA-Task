import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Task} from "../../models/task/task";
import {NewTask} from "../../models/task/new-task";
import {UpdateTask} from "../../models/task/update-task";

@Injectable()
export class TaskService {
  private url: string = environment.apiUrl + '/tasks';

  constructor(private httpClient: HttpClient) { }

  public getTasks() {
    return this.httpClient.get<Task[]>(this.url);
  }

  public getTaskById(id: number) {
    return this.httpClient.get<Task>(`${this.url}/${id}`)
  }

  public createTask(task: NewTask) {
    return this.httpClient.post<Task>(this.url, task);
  }

  public updateTask(task: UpdateTask) {
    return this.httpClient.put(this.url, task);
  }

  public deleteTask(id: number) {
    return this.httpClient.delete(`${this.url}/${id}`);
  }
}
