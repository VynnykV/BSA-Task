import {Team} from "../team/team";
import {User} from "../user/user";

export interface Project {
  id: number;
  author: User;
  team: Team;
  name: string;
  description: string;
  deadline: Date;
  createdAt: Date;
}
