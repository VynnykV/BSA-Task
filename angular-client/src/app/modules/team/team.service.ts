import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment";
import { Team } from "../../models/team/team";
import { NewTeam } from "../../models/team/new-team";
import { UpdateTeam } from "../../models/team/update-team";

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  private url: string = environment.apiUrl + '/teams';

  constructor(private httpclient: HttpClient) { }

  public getTeams() {
    return this.httpclient.get<Team[]>(this.url);
  }

  public getTeamById(id: number) {
    return this.httpclient.get<Team>(`${this.url}/${id}`)
  }

  public createTeam(team: NewTeam) {
    return this.httpclient.post<Team>(this.url, team);
  }

  public updateTeam(team: UpdateTeam) {
    return this.httpclient.put(this.url, team);
  }

  public deleteTeam(id: number) {
    return this.httpclient.delete(`${this.url}/${id}`);
  }
}
