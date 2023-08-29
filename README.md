# ChopShop.Api launch as a Docker container

docker build -t chop-shop -f Dockerfile .
docker run -d -p 127.0.0.1:80:80 chop-shop
curl http://localhost:80/menu