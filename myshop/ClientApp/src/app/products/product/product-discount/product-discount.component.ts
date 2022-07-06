import { Component, Input, OnInit } from '@angular/core';
import { Discount } from 'src/app/shared/models/discount';

@Component({
  selector: 'app-product-discount',
  templateUrl: './product-discount.component.html',
  styleUrls: ['./product-discount.component.scss']
})
export class ProductDiscountComponent implements OnInit {
  @Input() discount!: Discount;
  constructor() { }

  ngOnInit(): void {
  }

}
