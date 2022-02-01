export interface UpdateUser {
  id: number;
  teamId?: number;
  firstName: string;
  lastName: string;
  email: string;
  birthDay: Date;
}
