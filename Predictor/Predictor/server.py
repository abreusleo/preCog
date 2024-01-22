import grpc
from concurrent import futures
import time
import server_pb2_grpc as pb2_grpc
import server_pb2 as pb2


class Server(pb2_grpc.ServerServicer):

    def __init__(self, *args, **kwargs):
        pass

    def RecordRoute(self, request, context):
        message = request
        print("Received a request! This is the number someone sent:" , request.numberExample)
        result = f'Hey! Received this message "{message.example}" from API.'
        result = {'result': result}

        return pb2.ReturnObj(**result)


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    pb2_grpc.add_ServerServicer_to_server(Server(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("Server running!")
    server.wait_for_termination()


if __name__ == '__main__':
    serve()