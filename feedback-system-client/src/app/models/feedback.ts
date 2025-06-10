// Student ID: 00016119

import { User } from "./user";
import { Category } from "./category";

export interface Feedback {
    feedbackId: number;
    content: string;
    createdAt: string;
    isApproved: boolean;
    userId: number;
    categoryId: number;
    user?: User;
    category?: Category;
  }
  