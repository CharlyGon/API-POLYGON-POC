ver = latest
project_name = api-polygon
aws_region = us-east-2
aws_account_id = 339713010993
full_image_name = $(aws_account_id).dkr.ecr.$(aws_region).amazonaws.com/$(project_name):$(ver)
network = api-polygon

all:

auth:
	aws ecr get-login-password --region $(aws_region) | docker login --username AWS --password-stdin $(aws_account_id).dkr.ecr.$(aws_region).amazonaws.com

build:
	docker build -t ${full_image_name} .

runContainer:
	docker run --restart=always --network $(network) -p 5235:5235 ${full_image_name}

push:
	docker push ${full_image_name}

pull:
	docker pull ${full_image_name}
