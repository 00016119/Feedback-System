// Student ID: 00016119
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { FeedbackService } from '../../../services/feedback';
import { CategoryService } from '../../../services/category';
import { UserService } from '../../../services/user';

import { Feedback } from '../../../models/feedback';
import { Category } from '../../../models/category';
import { User } from '../../../models/user';

@Component({
  selector: 'app-feedback-edit',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './feedback-edit.html',
  styleUrls: ['./feedback-edit.css']
})
export class FeedbackEditComponent implements OnInit {
  feedbackId!: number;
  feedback: Feedback | null = null;
  categories: Category[] = [];
  users: User[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private feedbackService: FeedbackService,
    private categoryService: CategoryService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    this.feedbackId = Number(this.route.snapshot.paramMap.get('id'));

    this.categoryService.getAll().subscribe(cats => this.categories = cats);
    this.userService.getAll().subscribe(users => this.users = users);

    this.feedbackService.getById(this.feedbackId).subscribe({
      next: (data) => {
        this.feedback = data;
      },
      error: (err) => {
        console.error('Feedback not found', err);
        alert('Feedback not found.');
        this.router.navigate(['/feedbacks']);
      }
    });
  }

  updateFeedback() {
    if (!this.feedback) return;

    this.feedbackService.update(this.feedbackId, this.feedback).subscribe({
      next: () => {
        alert('Feedback updated!');
        this.router.navigate(['/feedbacks']);
      },
      error: (err) => {
        console.error('Update failed', err);
        alert('Error updating feedback.');
      }
    });
  }
}
