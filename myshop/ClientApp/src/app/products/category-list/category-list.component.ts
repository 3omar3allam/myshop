import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from 'src/app/shared/models/category';
import { CategoryService } from 'src/app/shared/services/category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {
  @Input() defaultCategory?: number;
  categories$!: Observable<Category[]>;

  @Output() categoryChanged = new EventEmitter<number | undefined>();

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categories$ = this.categoryService.getCategories();
  }

  changeCategory(event: Event) {
    const categoryId = +(event.target as HTMLSelectElement).value;
    if (!categoryId) {
      this.categoryChanged.emit(undefined);
    }
    this.categoryChanged.emit(categoryId);
  }
}
