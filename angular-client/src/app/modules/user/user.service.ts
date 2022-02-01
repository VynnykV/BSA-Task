import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {User} from "../../models/user/user";
import {NewUser} from "../../models/user/new-user";
import {UpdateUser} from "../../models/user/update-user";

@Injectable()
export class UserService {
  private url: string = environment.apiUrl + '/users';

  constructor(private httpClient: HttpClient) { }

  public getUsers() {
    return this.httpClient.get<User[]>(this.url);
  }

  public getUserById(id: number) {
    return this.httpClient.get<User>(`${this.url}/${id}`)
  }

  public createUser(user: NewUser) {
    return this.httpClient.post<User>(this.url, user);
  }

  public updateUser(user: UpdateUser) {
    return this.httpClient.put(this.url, user);
  }

  public deleteUser(id: number) {
    return this.httpClient.delete(`${this.url}/${id}`);
  }
}
