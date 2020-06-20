import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Bottlecap, Space } from '../../../../shared/models';
import { SpaceService } from '../space.service';

@Component({
  selector: 'app-space-area',
  templateUrl: './space-area.component.html',
  styleUrls: ['./space-area.component.css']
})
export class SpaceAreaComponent implements OnInit {

	spaceCaps: Bottlecap[];

  constructor(private spaceService: SpaceService) { }

	ngOnInit(): void {
		this.spaceService.getSpaceBottlecaps();
		this.spaceService.spacesChanged.subscribe(spaces => {
			this.spaceCaps = spaces.slice();
		})
  }

	onDragEnded(event, spaceCapId) {
		let element = event.source.getRootElement();
		let boundingClientRect = element.getBoundingClientRect();
		let parentPosition = this.getPosition(element);
		let x = boundingClientRect.x - parentPosition.left;
		let y = boundingClientRect.y - parentPosition.top;
		console.log('x: ' + (boundingClientRect.x - parentPosition.left), 'y: ' + (boundingClientRect.y - parentPosition.top));
		this.updatePlace(x, y, spaceCapId);
	}

	updatePlace(x, y, spaceCapId) {
		console.log("spaceCapId: ", spaceCapId);
		this.spaceService.updatePlace(new Space());
	}

	getPosition(el) {
		let x = 0;
		let y = 0;
		while (el && !isNaN(el.offsetLeft) && !isNaN(el.offsetTop)) {
			x += el.offsetLeft - el.scrollLeft;
			y += el.offsetTop - el.scrollTop;
			el = el.offsetParent;
		}
		return { top: y, left: x };
	}

	checkSpaces() {
		console.log("spaces in this.spaceService.spaceBottleCapCollection: ", this.spaceService.spaceBottleCapCollection);
		console.log("spaces in this.spaceCaps: ", this.spaceCaps);
	}
}
