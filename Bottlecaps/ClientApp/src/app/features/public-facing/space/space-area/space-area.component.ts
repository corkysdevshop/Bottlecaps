import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Bottlecap, Space } from '../../../../shared/models';
import { SpaceService } from '../space.service';
import { CdkDrag } from '@angular/cdk/drag-drop';

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
		}, (err) => { console.log("err: ", err);})
  }

	onDragEnded(event: CdkDrag, bottlecap: Bottlecap) {
		console.log("onDragEnded: ",event);
	/*
		let bottlecapElement = event.source.getRootElement();
		console.log("element: ", bottlecapElement);

		let boundingClientRect = bottlecapElement.getBoundingClientRect();
		console.log("boundingClientRect: ", boundingClientRect);

		let parentPosition = this.getPosition(bottlecapElement);
		console.log("parentPosition: ", parentPosition);

		let x = boundingClientRect.x - parentPosition.left;
		console.log("boundingClientRect.x: ",boundingClientRect.x," - parentPosition.left: ",parentPosition.left," = x: ", x);

		let y = boundingClientRect.y - parentPosition.top;
		console.log("y: ", y);
    

		console.log('x: ' + x,
			          'y: ' + y);
		this.updatePlace(x, y, bottlecap.bottlecapId);*/
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

	updatePlace(x: number, y: number, spaceCapId: number) {
		const space = new Space();
		space.SpaceId = spaceCapId.toString();
		space.PositionX = x.toString();
		space.PositionY = y.toString();
		console.log("updatePlace x: ", x, " y: ", y);
		this.spaceService.updatePlace(space);
	}

	checkSpace(event) {
    console.log("checkSpace()")
		console.log("event: ", event);
		let element = event.source.getRootElement();
		console.log("element: ", element);
		let boundingClientRect = element.getBoundingClientRect();
		console.log("boundingClientRect: ", boundingClientRect);
		let parentPosition = this.getPosition(element);
		console.log("parentPosition: ", parentPosition);
		let x = boundingClientRect.x - parentPosition.left;
		console.log("x: ", x);
		let y = boundingClientRect.y - parentPosition.top;
		console.log("y: ", y);
	}
	checkSpaces(event) {
		console.log("spaces in this.spaceService.spaceBottleCapCollection: ", this.spaceService.spaceBottleCapCollection);
		console.log("spaces in this.spaceCaps: ", this.spaceCaps);

		this.resetPositions();
	  console.log("spaces in this.spaceCaps: ", this.spaceCaps);
	}
	resetPositions() {
		for (let space of this.spaceCaps) {
			this.updatePlace(10, 10, space.bottlecapId);
		}
	}
}
