import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {Project} from "../../models/project/project";
import {NewProject} from "../../models/project/new-project";
import {UpdateProject} from "../../models/project/update-project";

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private url: string = environment.apiUrl + '/projects';

  constructor(private httpClient: HttpClient) { }

  public getProjects() {
    return this.httpClient.get<Project[]>(this.url);
  }

  public getProjectById(id: number) {
    return this.httpClient.get<Project>(`${this.url}/${id}`)
  }

  public createProject(project: NewProject) {
    return this.httpClient.post<Project>(this.url, project);
  }

  public updateProject(project: UpdateProject) {
    return this.httpClient.put(this.url, project);
  }

  public deleteProject(id: number) {
    return this.httpClient.delete(`${this.url}/${id}`);
  }
}
