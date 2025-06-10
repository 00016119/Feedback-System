// src/app/models/user.model.ts

import { Feedback } from './feedback';
import { Role } from './role';

export interface User {
  userId: number;
  username: string;
  email: string;
  passwordHash: string;
  roleId: number;
  role?: Role;
  feedbacks?: Feedback[];
}
