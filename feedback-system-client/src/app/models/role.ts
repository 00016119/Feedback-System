// src/app/models/role.ts
// Student ID: 00016119

import { User } from './user';

export interface Role {
  roleId: number;
  name: string;
  description: string;
  users?: User[];
}
