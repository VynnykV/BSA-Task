import {Team} from "../team/team";

export interface User {
  id: number;
  team?: Team;
  firstName: string;
  lastName: string;
  email: string;
  registeredAt: Date;
  birthDay: Date;
}
