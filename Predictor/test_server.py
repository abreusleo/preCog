import grpc
from concurrent import futures
import time
import test_pb2_grpc as pb2_grpc
import test_pb2 as pb2


class TestService(pb2_grpc.TestServicer):

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
    pb2_grpc.add_TestServicer_to_server(TestService(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("Server running!")
    server.wait_for_termination()


if __name__ == '__main__':
    serve()