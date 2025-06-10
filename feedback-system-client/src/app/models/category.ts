// src/app/models/category.ts
// Student ID: 00016119

import { Feedback } from './feedback';

export interface Category {
  categoryId: number;
  name: string;
  description: string;
  feedbacks?: Feedback[];
}
