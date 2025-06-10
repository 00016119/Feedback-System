// Student ID: 00016119
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

import { FeedbackService } from '../../../services/feedback';
import { CategoryService } from '../../../services/category';
import { UserService } from '../../../services/user';

import { Feedback } from '../../../models/feedback';
import { Category } from '../../../models/category';
import { User } from '../../../models/user';

@Component({
  selector: 'app-feedback-create',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './feedback-create.html',
  styleUrls: ['./feedback-create.css']
})
export class FeedbackCreateComponent {
  feedback: Partial<Feedback> = {
    content: '',
    categoryId: 0,
    userId: 0,
    isApproved: false
  };

  categories: Category[] = [];
  users: User[] = [];

  constructor(
    private feedbackService: FeedbackService,
    private categoryService: CategoryService,
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.categoryService.getAll().subscribe(cats => this.categories = cats);
    this.userService.getAll().subscribe(users => this.users = users);
  }

  submitFeedback() {
    if (!this.feedback.content || !this.feedback.categoryId || !this.feedback.userId) {
      alert('Please fill all required fields.');
      return;
    }

    this.feedbackService.create(this.feedback as Feedback).subscribe({
      next: () => {
        alert('Feedback submitted!');
        this.router.navigate(['/feedbacks']);
      },
      error: (err) => {
        console.error('Error creating feedback', err);
        alert('Something went wrong.');
      }
    });
  }
}
