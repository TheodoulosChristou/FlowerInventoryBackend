import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FlowerService } from '../services/flower.service';
import { Flower } from '../../../../models/flower.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Category } from '../../../../models/category.model';
declare var bootstrap: any;
@Component({
  selector: 'app-flower-list',
  imports: [RouterModule,CommonModule,FormsModule],
  templateUrl: './flower-list.component.html',
  styleUrl: './flower-list.component.css'
})
export class FlowerListComponent {
  flowers: Flower[] = [];
  categories: Category[] = [];
  
  selectedFlower: Flower = {
    flowerId:0,
    name:'',
    category:null,
    categoryId:0,
    price:0
  }; 
  selectedFlowerToDelete: Flower | null = null;

  constructor(private flowerService: FlowerService) {}

  ngOnInit(): void {
    this.getAllFlowers();
    this.getAllCategories();
  }

  getAllFlowers(){
    this.flowerService.getFlowers().subscribe({
      next: (data) => this.flowers = data,
      error: (err) => console.error('Error fetching flowers:', err)
    });
  }

  getAllCategories() {
    this.flowerService.getAllCategories().subscribe({
      next: (data: Category[]) => this.categories = data,
      error: (err) => {
        console.error('Failed to load categories', err);
        this.showToast('Failed to load categories', 'danger');
      }
    });
  }
  
  openEditModal(flower: any) {
    this.selectedFlower = { ...flower };
    const modalElement = document.getElementById('editFlowerModal');
    const modal = new bootstrap.Modal(modalElement);
    modal.show();
  }

  saveFlower(selectedFlower: Flower) {
    console.log(selectedFlower);
  
    // Nullify the category navigation property if needed for the backend
    selectedFlower.category = null;
  
    this.flowerService.updateFlower(selectedFlower).subscribe({
      next: () => {
        // Refresh the flower list
        this.getAllFlowers();
        this.showToast('Flower updated successfully!', 'success');
  
        // Close the modal safely
        const modalElement = document.getElementById('editFlowerModal');
        const modal = bootstrap.Modal.getInstance(modalElement);
        modal?.hide();
      },
      error: (err) => {
        console.error('Failed to update flower:', err);
        this.showToast('Failed to update flower.', 'danger');
      }
    });
  }

  openDeleteModal(flower: Flower) {
    this.selectedFlowerToDelete = flower;
  
    const modalEl = document.getElementById('deleteConfirmationModal');
    const modal = new bootstrap.Modal(modalEl);
    modal.show();
  }
  
  confirmDeleteFlower() {
    if (!this.selectedFlowerToDelete) return;
      
    this.flowerService.deleteFlower(this.selectedFlowerToDelete).subscribe({
      next: () => {
        this.getAllFlowers();
        this.showToast('Flower deleted successfully.', 'success');
  
        const modalEl = document.getElementById('deleteConfirmationModal');
        const modal = bootstrap.Modal.getInstance(modalEl);
        modal?.hide();
      },
      error: (err) => {
        console.error('Delete failed:', err);
        this.showToast('Failed to delete flower.', 'danger');
      }
    });
  }
  
  showToast(message: string, type: 'success' | 'danger') {
    const toastEl = document.getElementById('toastMessage');
    const toastBody = document.getElementById('toastBody');
  
    if (toastEl && toastBody) {
      toastEl.classList.remove('bg-success', 'bg-danger');
      toastEl.classList.add(type === 'success' ? 'bg-success' : 'bg-danger');
      toastBody.textContent = message;
  
      const toast = new bootstrap.Toast(toastEl);
      toast.show();
    }
  }


}
